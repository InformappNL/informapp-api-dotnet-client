using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Converters;
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
using System.Linq;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="RestSharpApiClient{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="clientFactory"></param>
        /// <param name="requestFactory"></param>
        /// <param name="queryStringBuilderFactory"></param>
        /// <param name="converter"></param>
        public RestSharpApiClient(
            IClientFactory clientFactory,
            IRequestFactory requestFactory,
            IQueryStringBuilderFactory queryStringBuilderFactory,
            IConverter<ResponseStatus?, ResponseStatusCode?> converter)
        {
            Argument.NotNull(clientFactory, nameof(clientFactory));
            Argument.NotNull(requestFactory, nameof(requestFactory));
            Argument.NotNull(queryStringBuilderFactory, nameof(queryStringBuilderFactory));
            Argument.NotNull(converter, nameof(converter));

            _clientFactory = clientFactory;

            _requestFactory = requestFactory;

            _queryStringBuilderFactory = queryStringBuilderFactory;

            _converter = converter;
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

            apiRequest.AddHeader("cache-control", "no-cache");

            AddBody(request, apiRequest);

            var apiResponse = await client.ExecuteTaskAsync<TResponse>(apiRequest, cancellationToken);

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
                ContentType = apiResponse.ContentType,
            };

            if (apiResponse.IsSuccessful == true)
            {
                response.Model = apiResponse.Data;
                response.ContentModel = apiResponse.Data;
            }

            if (apiResponse.Headers != null)
            {
                response.Headers = apiResponse.Headers
                    .Where(x => x.Type == ParameterType.HttpHeader)
                    .Where(x => x.Value is string)
                    .Select(x => new ResponseHeader
                    {
                        Name = x.Name,
                        Value = x.Value as string
                    })
                    .ToList();
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
                    case ContentType.Json:
                        apiRequest.AddJsonBody(request.Model);
                        break;
                    case ContentType.FormUrlEncoded:
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
    }
}
