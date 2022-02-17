using ConnectedDevelopment.InformSystem.WebApi.Client.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using ConnectedDevelopment.InformSystem.WebApi.Client.QueryStringProviders;
using ConnectedDevelopment.InformSystem.WebApi.Client.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Clients.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IApiClient{TRequest, TResponse}"/> to set query on request
    /// </summary>
    public class QueryApiClientDecorator<TRequest, TResponse> : Decorator<IApiClient<TRequest, TResponse>>,
        IApiClient<TRequest, TResponse>

        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        private readonly IApiClient<TRequest, TResponse> _apiClient;

        private readonly IQueryProvider<TRequest> _queryProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryApiClientDecorator{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="apiClient">The instance to decorate</param>
        /// <param name="queryProvider"></param>
        public QueryApiClientDecorator(
            IApiClient<TRequest, TResponse> apiClient,
            IQueryProvider<TRequest> queryProvider) : base(apiClient)
        {
            Argument.NotNull(apiClient, nameof(apiClient));
            Argument.NotNull(queryProvider, nameof(queryProvider));

            _apiClient = apiClient;

            _queryProvider = queryProvider;
        }

        /// <summary>
        /// Set query on request and execute request
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

            if (request.Context.Query == null)
            {
                string query = _queryProvider.GetQueryString(request.Model);

                request.Context.Query = query;
            }

            return _apiClient.Execute(request, cancellationToken);
        }
    }
}
