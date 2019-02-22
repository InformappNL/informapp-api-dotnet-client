using Informapp.InformSystem.WebApi.Client.Arguments;
using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Client.EndPointProviders;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Models.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Clients.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IApiClient{TRequest, TResponse}"/> to set endpoint on request
    /// </summary>
    public class EndPointApiClientDecorator<TRequest, TResponse> : Decorator<IApiClient<TRequest, TResponse>>, 
        IApiClient<TRequest, TResponse>

        where TRequest : class, IRequest<TResponse>
        where TResponse : class
    {
        private readonly IApiClient<TRequest, TResponse> _apiClient;

        private readonly IEndPointProvider _endPointProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="EndPointApiClientDecorator{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="apiClient">The instance to decorate</param>
        /// <param name="endPointProvider"></param>
        public EndPointApiClientDecorator(
            IApiClient<TRequest, TResponse> apiClient,
            IEndPointProvider endPointProvider) : base(apiClient)
        {
            Argument.NotNull(apiClient, nameof(apiClient));
            Argument.NotNull(endPointProvider, nameof(endPointProvider));

            _apiClient = apiClient;

            _endPointProvider = endPointProvider;
        }

        /// <summary>
        /// Set endpoint and execute request
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

            if (request.Context.EndPoint == null)
            {
                request.Context.EndPoint = _endPointProvider.GetEndPoint();
            }

            return _apiClient.Execute(request, cancellationToken);
        }
    }
}
