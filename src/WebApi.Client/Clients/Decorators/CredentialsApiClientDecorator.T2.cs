using ConnectedDevelopment.InformSystem.WebApi.Client.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Configuration;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using ConnectedDevelopment.InformSystem.WebApi.Client.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Clients.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IApiClient{TRequest, TResponse}"/> to set credentials on request
    /// </summary>
    public class CredentialsApiClientDecorator<TRequest, TResponse> : Decorator<IApiClient<TRequest, TResponse>>,
        IApiClient<TRequest, TResponse>

        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        private readonly IApiClient<TRequest, TResponse> _apiClient;

        private readonly IOptions<ApiConfiguration> _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="CredentialsApiClientDecorator{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="apiClient">The instance to decorate</param>
        /// <param name="options">The options</param>
        public CredentialsApiClientDecorator(
            IApiClient<TRequest, TResponse> apiClient,
            IOptions<ApiConfiguration> options) : base(apiClient)
        {
            Argument.NotNull(apiClient, nameof(apiClient));
            Argument.NotNull(options, nameof(options));

            _apiClient = apiClient;

            _options = options;
        }

        /// <summary>
        /// Set credentials and execute request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public Task<ApiResponse<TResponse>> Execute(ApiRequest<TRequest> request, CancellationToken cancellationToken)
        {
            Argument.NotNull(request, nameof(request));

            if (request.Anonymous != true)
            {
                if (request.Credentials == null)
                {
                    request.Credentials = new ApiCredentials();
                }

                var credentials = request.Credentials;

                if (string.IsNullOrEmpty(credentials.Username) &&
                    string.IsNullOrEmpty(credentials.GetPassword()))
                {
                    credentials.Username = _options.Value.UserName;
                    credentials.Password = _options.Value.Password;
                }
            }

            return _apiClient.Execute(request, cancellationToken);
        }
    }
}
