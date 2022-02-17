using ConnectedDevelopment.InformSystem.WebApi.Client.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.BearerTokenProviders;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using ConnectedDevelopment.InformSystem.WebApi.Client.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.OAuth2.OAuth2Token;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Clients.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IApiClient{TRequest, TResponse}"/> to set bearer token on request
    /// </summary>
    public class BearerTokenApiClientDecorator<TRequest, TResponse> : Decorator<IApiClient<TRequest, TResponse>>,
        IApiClient<TRequest, TResponse>

        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        private readonly IApiClient<TRequest, TResponse> _apiClient;

        private readonly IBearerTokenProvider<OAuth2TokenV1Request> _bearerTokenProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="BearerTokenApiClientDecorator{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="apiClient">The instance to decorate</param>
        /// <param name="bearerTokenProvider"></param>
        public BearerTokenApiClientDecorator(
            IApiClient<TRequest, TResponse> apiClient,
            IBearerTokenProvider<OAuth2TokenV1Request> bearerTokenProvider) : base(apiClient)
        {
            Argument.NotNull(apiClient, nameof(apiClient));
            Argument.NotNull(bearerTokenProvider, nameof(bearerTokenProvider));

            _apiClient = apiClient;

            _bearerTokenProvider = bearerTokenProvider;
        }

        /// <summary>
        /// Set bearer token and execute request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public async Task<ApiResponse<TResponse>> Execute(ApiRequest<TRequest> request, CancellationToken cancellationToken)
        {
            Argument.NotNull(request, nameof(request));

            if (request.Anonymous != true &&
                request.Credentials.Kind == CredentialsKind.Default)
            {
                if (request.BearerToken == null)
                {
                    request.BearerToken = new ApiBearerToken();
                }

                if (request.BearerToken.HasToken != true)
                {
                    var tokenResponse = await _bearerTokenProvider
                        .GetToken(request, cancellationToken)
                        .ConfigureAwait(Await.Default);

                    if (tokenResponse.Response.IsSuccessful == true)
                    {
                        request.BearerToken.Token = tokenResponse.AccessToken;
                    }
                }
            }

            var response = await _apiClient
                .Execute(request, cancellationToken)
                .ConfigureAwait(Await.Default);

            return response;
        }
    }
}
