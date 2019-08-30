using Informapp.InformSystem.WebApi.Client.Arguments;
using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Client.PathProviders;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Models.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Clients.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IApiClient{TRequest, TResponse}"/> to set path on request
    /// </summary>
    public class PathApiClientDecorator<TRequest, TResponse> : Decorator<IApiClient<TRequest, TResponse>>,
        IApiClient<TRequest, TResponse>

        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        private readonly IApiClient<TRequest, TResponse> _apiClient;

        private readonly IPathProvider<TRequest> _pathProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="PathApiClientDecorator{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="apiClient">The instance to decorate</param>
        /// <param name="pathProvider"></param>
        public PathApiClientDecorator(
            IApiClient<TRequest, TResponse> apiClient,
            IPathProvider<TRequest> pathProvider) : base(apiClient)
        {
            Argument.NotNull(apiClient, nameof(apiClient));
            Argument.NotNull(pathProvider, nameof(pathProvider));

            _apiClient = apiClient;

            _pathProvider = pathProvider;
        }

        /// <summary>
        /// Set path on request and execute request
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

            if (request.Context.Path == null)
            {
                var path = _pathProvider.GetPath(request.Model);

                request.Context.Path = path;
            }

            return _apiClient.Execute(request, cancellationToken);
        }
    }
}
