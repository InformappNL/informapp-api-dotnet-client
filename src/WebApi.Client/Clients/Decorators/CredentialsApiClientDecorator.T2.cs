using Informapp.InformSystem.WebApi.Client.Arguments;
using Informapp.InformSystem.WebApi.Client.CredentialsProviders;
using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Models.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Clients.Decorators
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

        private readonly ICredentialsProvider _credentialsProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="CredentialsApiClientDecorator{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="apiClient">The instance to decorate</param>
        /// <param name="credentialsProvider"></param>
        public CredentialsApiClientDecorator(
            IApiClient<TRequest, TResponse> apiClient,
            ICredentialsProvider credentialsProvider) : base(apiClient)
        {
            Argument.NotNull(apiClient, nameof(apiClient));
            Argument.NotNull(credentialsProvider, nameof(credentialsProvider));

            _apiClient = apiClient;

            _credentialsProvider = credentialsProvider;
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
                    credentials.Username = _credentialsProvider.GetUserName();
                    credentials.Password = _credentialsProvider.GetPassword();
                }
            }

            return _apiClient.Execute(request, cancellationToken);
        }
    }
}
