using Informapp.InformSystem.WebApi.Client.Arguments;
using Informapp.InformSystem.WebApi.Client.AttributeProviders;
using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Client.Files;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Requires;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Models.Http;
using Informapp.InformSystem.WebApi.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Informapp.InformSystem.WebApi.Client.Clients.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IApiClient{TRequest, TResponse}"/> to set the upload file on the request
    /// </summary>
    public class UploadFileApiClientDecorator<TRequest, TResponse> : Decorator<IApiClient<TRequest, TResponse>>,
        IApiClient<TRequest, TResponse>

        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        private static readonly UploadFileRequestAttribute _attribute = AttributeProvider.Create<TRequest, UploadFileRequestAttribute>(true)
            .ThrowIfMultiple()
            .Attribute;

        private readonly IApiClient<TRequest, TResponse> _apiClient;

        private readonly IEnumerable<IUploadFileMapper<TRequest, TResponse>> _mappers;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFileApiClientDecorator{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="apiClient">The instance to decorate</param>
        public UploadFileApiClientDecorator(
            IApiClient<TRequest, TResponse> apiClient,
            IEnumerable<IUploadFileMapper<TRequest, TResponse>> mappers) : base(apiClient)
        {
            Argument.NotNull(apiClient, nameof(apiClient));
            Argument.NotNullOrEmpty(mappers, nameof(mappers));

            _apiClient = apiClient;

            _mappers = mappers;
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

                request.UploadFile.ContentType = MimeMapping.GetMimeMapping(request.UploadFile.FileName);

                request.UploadFile.FileParameterName = _attribute.FileParameterName;
            }

            return _apiClient.Execute(request, cancellationToken);
        }
    }
}
