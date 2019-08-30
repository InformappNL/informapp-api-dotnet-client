using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Converters;
using Informapp.InformSystem.WebApi.Client.MimeMappers;
using Informapp.InformSystem.WebApi.Client.QueryStrings;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.RestSharp.Arguments;
using Informapp.InformSystem.WebApi.Client.RestSharp.ClientFactories;
using Informapp.InformSystem.WebApi.Client.RestSharp.RequestFactories;
using Informapp.InformSystem.WebApi.Client.RestSharp.Responses;
using Informapp.InformSystem.WebApi.Models.Http;
using Informapp.InformSystem.WebApi.Models.Requests;
using RestSharp;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.RestSharp.Clients
{
    /// <summary>
    ///  Generic RestSharp implementation for API client class
    /// </summary>
    public class RestSharpApiClient<TRequest, TResponse> : IApiClient<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        private readonly IClientFactory _clientFactory;

        private readonly IRequestFactory _requestFactory;

        private readonly IQueryStringBuilderFactory _queryStringBuilderFactory;

        private readonly IConverter<ResponseStatus?, ResponseStatusCode?> _converter;

        private readonly IMimeMapper _mimeMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestSharpApiClient{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="clientFactory">The client factory</param>
        /// <param name="requestFactory">The request factory</param>
        /// <param name="queryStringBuilderFactory">The query string factory</param>
        /// <param name="converter">The converter</param>
        /// <param name="mimeMapper">The mime mapper</param>
        public RestSharpApiClient(
            IClientFactory clientFactory,
            IRequestFactory requestFactory,
            IQueryStringBuilderFactory queryStringBuilderFactory,
            IConverter<ResponseStatus?, ResponseStatusCode?> converter,
            IMimeMapper mimeMapper)
        {
            Argument.NotNull(clientFactory, nameof(clientFactory));
            Argument.NotNull(requestFactory, nameof(requestFactory));
            Argument.NotNull(queryStringBuilderFactory, nameof(queryStringBuilderFactory));
            Argument.NotNull(converter, nameof(converter));
            Argument.NotNull(mimeMapper, nameof(mimeMapper));

            _clientFactory = clientFactory;

            _requestFactory = requestFactory;

            _queryStringBuilderFactory = queryStringBuilderFactory;

            _converter = converter;

            _mimeMapper = mimeMapper;
        }

        /// <summary>
        /// Execute request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public async Task<ApiResponse<TResponse>> Execute(ApiRequest<TRequest> request, CancellationToken cancellationToken)
        {
            Argument.NotNull(request, nameof(request));

            var client = _clientFactory.Create(request);

            var apiRequest = _requestFactory.Create(request);

            ApiDownloadFileResponse downloadFile = null;

            if (request.IsFileDownload == true)
            {
                client.ConfigureWebRequest(x => x.AllowReadStreamBuffering = false);

                downloadFile = new ApiDownloadFileResponse();

                apiRequest.AdvancedResponseWriter = (stream, httpResponse) => SetDownloadFile(downloadFile, stream, httpResponse);
            }

            apiRequest.AddHeader(HttpRequestHeaderConstants.CacheControl, "no-cache");

            if (request.IsFileUpload == true)
            {
                client.ConfigureWebRequest(x => x.AllowWriteStreamBuffering = false);

                apiRequest.AddFile(
                    request.UploadFile.ParameterName,
                    request.UploadFile.File.CopyTo,
                    request.UploadFile.FileName,
                    request.UploadFile.Size.Value,
                    request.UploadFile.ContentType);
            }
            else
            {
                client.ConfigureWebRequest(x => x.AllowWriteStreamBuffering = true);

                AddBody(request, apiRequest);
            }

            var apiResponse = await client
                .ExecuteTaskAsync<TResponse>(apiRequest, cancellationToken)
                .ConfigureAwait(Await.Default);

            var response = new RestSharpApiResponse<TResponse>
            {
                RestRequest = apiRequest,
                RestResponse = apiResponse,

                IsSuccessful = apiResponse.IsSuccessful,
                StatusCode = apiResponse.StatusCode,
                ResponseStatus = _converter.Convert(apiResponse.ResponseStatus)
                    .ThrowIfNoValue()
                    .Value,

                Content = apiResponse.Content,
                DownloadFile = downloadFile,
            };

            if (apiResponse.IsSuccessful == true)
            {
                response.Model = apiResponse.Data;
                response.ContentModel = apiResponse.Data;
            }

            if (apiResponse.Headers != null)
            {
                var headers = apiResponse.Headers
                    .Where(x => x.Type == ParameterType.HttpHeader)
                    .Where(x => x.Value is string)
                    .Select(x => new ResponseHeader
                    {
                        Name = x.Name,
                        Value = x.Value as string
                    })
                    .ToList();

                response.Headers = new ResponseHeaders(headers);

                response.Headers.ContentLength = apiResponse.ContentLength;

                response.Headers.ContentType = apiResponse.ContentType;

                SetContentDispositionHeader(response, apiResponse);
            }

            return response;
        }

        private void AddBody(ApiRequest<TRequest> request, IRestRequest apiRequest)
        {
            if (request.Context.Method.HasValue == true &&
                HttpMethodHelper.HasRequestBody(request.Context.Method.Value) == true)
            {
                switch (request.Context.ContentType)
                {
                    case null:
                    case Models.Http.ContentType.Json:
                        apiRequest.AddJsonBody(request.Model);
                        break;
                    case Models.Http.ContentType.FormUrlEncoded:
                        AddFormUrlEncodedBody(request, apiRequest);
                        break;
                    default:
                        throw new InvalidOperationException("Unsupported value");
                }
            }
        }

        private void AddFormUrlEncodedBody(ApiRequest<TRequest> request, IRestRequest apiRequest)
        {
            string encoded = _queryStringBuilderFactory.Create()
                .Add(request.Model)
                .ToString();

            apiRequest.AddParameter(
                ContentTypeConstants.Application.FormUrlEncoded,
                encoded,
                ContentTypeConstants.Application.FormUrlEncoded,
                ParameterType.RequestBody);
        }

        private static void SetDownloadFile(ApiDownloadFileResponse downloadFile, Stream stream, IHttpResponse response)
        {
            Argument.NotNull(downloadFile, nameof(downloadFile));
            Argument.NotNull(stream, nameof(stream));
            Argument.NotNull(response, nameof(response));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var file = new MemoryStream();

                stream.CopyTo(file);

                file.Position = 0L;

                downloadFile.File = file;
            }
        }

        private void SetContentDispositionHeader(ApiResponse response, IRestResponse<TResponse> restResponse)
        {
            var header = response.Headers.GetHeader(HttpResponseHeaderConstants.ContentDisposition);

            if (header != null && header.HasValue == true)
            {
                var contentDisposition = new ContentDispositionHeader(header.Value);

                response.Headers.ContentDisposition = contentDisposition;

                if (response.DownloadFile != null)
                {
                    string fileName = contentDisposition.FileName;
                    string contentType = _mimeMapper.GetMimeMapping(fileName);

                    response.DownloadFile.ContentType = contentType;
                    response.DownloadFile.FileName = fileName;
                    response.DownloadFile.Size = restResponse.ContentLength;
                }
            }
        }
    }
}
