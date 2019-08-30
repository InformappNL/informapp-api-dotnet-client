using Informapp.InformSystem.WebApi.Client.Arguments;
using Informapp.InformSystem.WebApi.Client.AttributeProviders;
using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Models.Http;
using Informapp.InformSystem.WebApi.Models.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Clients.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IApiClient{TRequest, TResponse}"/> to set content type on request
    /// </summary>
    public class ContentTypeApiClientDecorator<TRequest, TResponse> : Decorator<IApiClient<TRequest, TResponse>>,
        IApiClient<TRequest, TResponse>

        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        private static readonly ContentTypeAttribute _attribute = AttributeProvider.Create<TRequest, ContentTypeAttribute>(true)
            .ThrowIfMultiple()
            .Attribute;

        private readonly IApiClient<TRequest, TResponse> _apiClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentTypeApiClientDecorator{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="apiClient">The instance to decorate</param>
        public ContentTypeApiClientDecorator(
            IApiClient<TRequest, TResponse> apiClient) : base(apiClient)
        {
            Argument.NotNull(apiClient, nameof(apiClient));

            _apiClient = apiClient;
        }

        /// <summary>
        /// Set content type and execute request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public Task<ApiResponse<TResponse>> Execute(ApiRequest<TRequest> request, CancellationToken cancellationToken)
        {
            Argument.NotNull(request, nameof(request));

            if (request.Context == null)
            {
                request.Context = new RequestContext();
            }

            if (request.Context.ContentType.HasValue == false)
            {
                if (_attribute != null)
                {
                    request.Context.ContentType = _attribute.ContentType;
                }
                else
                {
                    request.Context.ContentType = ContentType.Json;
                }
            }

            return _apiClient.Execute(request, cancellationToken);
        }
    }
}
