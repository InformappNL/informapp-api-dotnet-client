using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.IntegrationTool.Core.Loggers;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Clients
{
    /// <summary>
    /// Decorator class for <see cref="IApiClient{TRequest, TResponse}"/> to log on request
    /// </summary>
    public class LogApiClientDecorator<TRequest, TResponse> : Decorator<IApiClient<TRequest, TResponse>>,
        IApiClient<TRequest, TResponse>

        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        private readonly IApiClient<TRequest, TResponse> _apiClient;

        private readonly IApplicationLogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogApiClientDecorator{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="apiClient">The instance to decorate</param>
        /// <param name="logger">The logger instance to decorate</param>
        public LogApiClientDecorator(
            IApiClient<TRequest, TResponse> apiClient,
            IApplicationLogger logger) : base(apiClient)
        {
            Argument.NotNull(apiClient, nameof(apiClient));
            Argument.NotNull(logger, nameof(logger));

            _apiClient = apiClient;

            _logger = logger;
        }

        /// <summary>
        /// Log and execute request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public async Task<ApiResponse<TResponse>> Execute(ApiRequest<TRequest> request, CancellationToken cancellationToken)
        {
            Argument.NotNull(request, nameof(request));

            bool isInfoEnabled = _logger.IsInfoEnabled;

            if (isInfoEnabled == true)
            {
                _logger.InfoFormat("API request {0} {1}{2} {3}",
                    request.Context.Method,
                    request.Context.EndPoint,
                    request.Context.Path,
                    request.Context.Query);
            }

            var response = await _apiClient
                .Execute(request, cancellationToken)
                .ConfigureAwait(Await.Default);

            if (isInfoEnabled == true)
            {
                if (response.IsSuccessful == true)
                {
                    _logger.InfoFormat("API response Status: {0}, HttpStatusCode: {1}, RequestId: {2}",
                        response.ResponseStatus,
                        response.StatusCode,
                        response.Headers.RequestId);
                }
                else
                {
                    _logger.InfoFormat("API response Status: {0}, HttpStatusCode: {1}, RequestId: {2}, Content: {3}",
                        response.ResponseStatus,
                        response.StatusCode,
                        response.Headers.RequestId,
                        response.Content);
                }
            }

            return response;
        }
    }
}
