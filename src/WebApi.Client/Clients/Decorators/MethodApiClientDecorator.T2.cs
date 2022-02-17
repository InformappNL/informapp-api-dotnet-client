using ConnectedDevelopment.InformSystem.WebApi.Client.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using ConnectedDevelopment.InformSystem.WebApi.Client.MethodProviders;
using ConnectedDevelopment.InformSystem.WebApi.Client.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Clients.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IApiClient{TRequest, TResponse}"/> to set method on request
    /// </summary>
    public class MethodApiClientDecorator<TRequest, TResponse> : Decorator<IApiClient<TRequest, TResponse>>,
        IApiClient<TRequest, TResponse>

        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        private readonly IApiClient<TRequest, TResponse> _apiClient;

        private readonly IMethodProvider<TRequest> _methodProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodApiClientDecorator{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="apiClient">The instance to decorate</param>
        /// <param name="methodProvider"></param>
        public MethodApiClientDecorator(
            IApiClient<TRequest, TResponse> apiClient,
            IMethodProvider<TRequest> methodProvider) : base(apiClient)
        {
            Argument.NotNull(apiClient, nameof(apiClient));
            Argument.NotNull(methodProvider, nameof(methodProvider));

            _apiClient = apiClient;

            _methodProvider = methodProvider;
        }

        /// <summary>
        /// Set method on request and execute request
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

            if (request.Context.Method.HasValue == false)
            {
                request.Context.Method = _methodProvider.GetMethod();
            }

            return _apiClient.Execute(request, cancellationToken);
        }
    }
}
