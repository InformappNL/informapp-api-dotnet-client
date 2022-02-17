using ConnectedDevelopment.InformSystem.WebApi.Client.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.AttributeProviders;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using ConnectedDevelopment.InformSystem.WebApi.Client.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Clients.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IApiClient{TRequest, TResponse}"/> to set anonymous on request
    /// </summary>
    public class AnonymousApiClientDecorator<TRequest, TResponse> : Decorator<IApiClient<TRequest, TResponse>>,
        IApiClient<TRequest, TResponse>

        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        private static readonly AnonymousAttribute _attribute = AttributeProvider.Create<TRequest, AnonymousAttribute>(inherit: true)
            .ThrowIfMultiple()
            .Attribute;

        private readonly IApiClient<TRequest, TResponse> _apiClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnonymousApiClientDecorator{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="apiClient">The instance to decorate</param>
        public AnonymousApiClientDecorator(
            IApiClient<TRequest, TResponse> apiClient) : base(apiClient)
        {
            Argument.NotNull(apiClient, nameof(apiClient));

            _apiClient = apiClient;
        }

        /// <summary>
        /// Set anonymous and execute request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public Task<ApiResponse<TResponse>> Execute(ApiRequest<TRequest> request, CancellationToken cancellationToken)
        {
            Argument.NotNull(request, nameof(request));

            if (_attribute != null && request.Anonymous.HasValue == false)
            {
                request.Anonymous = true;
            }

            return _apiClient.Execute(request, cancellationToken);
        }
    }
}
