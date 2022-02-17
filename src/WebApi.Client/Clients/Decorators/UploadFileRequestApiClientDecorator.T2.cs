using ConnectedDevelopment.InformSystem.WebApi.Client.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.AttributeProviders;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using ConnectedDevelopment.InformSystem.WebApi.Client.Files;
using ConnectedDevelopment.InformSystem.WebApi.Client.MimeMappers;
using ConnectedDevelopment.InformSystem.WebApi.Client.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Models.Http;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Clients.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IApiClient{TRequest, TResponse}"/> to set the upload file on the request
    /// </summary>
    public class UploadFileRequestApiClientDecorator<TRequest, TResponse> : Decorator<IApiClient<TRequest, TResponse>>,
        IApiClient<TRequest, TResponse>

        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        private static readonly UploadFileRequestAttribute _attribute = AttributeProvider.Create<TRequest, UploadFileRequestAttribute>(inherit: true)
            .ThrowIfMultiple()
            .Attribute;

        private readonly IApiClient<TRequest, TResponse> _apiClient;

        private readonly IEnumerable<IUploadFileRequestMapper<TRequest, TResponse>> _mappers;

        private readonly IMimeMapper _mimeMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFileRequestApiClientDecorator{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="apiClient">The instance to decorate</param>
        /// <param name="mappers">The upload file mappers</param>
        /// <param name="mimeMapper">The mime mapper</param>
        public UploadFileRequestApiClientDecorator(
            IApiClient<TRequest, TResponse> apiClient,
            IEnumerable<IUploadFileRequestMapper<TRequest, TResponse>> mappers,
            IMimeMapper mimeMapper) : base(apiClient)
        {
            Argument.NotNull(apiClient, nameof(apiClient));
            Argument.NotNullOrEmpty(mappers, nameof(mappers));
            Argument.NotNull(mimeMapper, nameof(mimeMapper));

            _apiClient = apiClient;

            _mappers = mappers;

            _mimeMapper = mimeMapper;
        }

        /// <summary>
        /// Set the upload file on the request and execute request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public Task<ApiResponse<TResponse>> Execute(ApiRequest<TRequest> request, CancellationToken cancellationToken)
        {
            Argument.NotNull(request, nameof(request));

            bool isFileUpload = _attribute != null;

            if (isFileUpload == true)
            {
                request.IsFileUpload = isFileUpload;

                bool mapped = false;

                foreach (var mapper in _mappers)
                {
                    mapped = mapper.Map(request);

                    if (mapped == true)
                    {
                        break;
                    }
                }

                if (mapped == false)
                {
                    throw new InvalidOperationException("Failed to map upload file request");
                }

                // Set Content-Type if empty
                if (string.IsNullOrEmpty(request.UploadFile.ContentType) == true &&
                    string.IsNullOrEmpty(request.UploadFile.FileName) == false)
                {
                    request.UploadFile.ContentType = _mimeMapper.GetMimeMapping(request.UploadFile.FileName);
                }

                request.UploadFile.ParameterName = _attribute.FileParameterName;
            }

            return _apiClient.Execute(request, cancellationToken);
        }
    }
}
