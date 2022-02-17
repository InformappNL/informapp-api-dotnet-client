using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using ConnectedDevelopment.InformSystem.WebApi.Client.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Clients
{
    /// <summary>
    /// Decorator class for <see cref="IApiClient{TRequest, TResponse}"/> to log to console
    /// </summary>
    public class LogToConsoleApiClientDecorator<TRequest, TResponse> : Decorator<IApiClient<TRequest, TResponse>>,
        IApiClient<TRequest, TResponse>

        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        private readonly IApiClient<TRequest, TResponse> _apiClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogToConsoleApiClientDecorator{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="apiClient">The instance to decorate</param>
        public LogToConsoleApiClientDecorator(
            IApiClient<TRequest, TResponse> apiClient) : base(apiClient)
        {
            Argument.NotNull(apiClient, nameof(apiClient));

            _apiClient = apiClient;
        }

        /// <summary>
        /// Ensure request is not null and execute request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public Task<ApiResponse<TResponse>> Execute(ApiRequest<TRequest> request, CancellationToken cancellationToken)
        {
            Argument.NotNull(request, nameof(request));

            string message = string.Format(
                CultureInfo.InvariantCulture,
                "{0} {1} {2} {3} {4}",
                nameof(Execute),
                request.Context.Method,
                request.Context.EndPoint,
                request.Context.Path,
                request.Context.Query);

            Console.WriteLine(message);

            Debug.WriteLine(message);

            return _apiClient.Execute(request, cancellationToken);
        }
    }
}
