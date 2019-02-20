using Informapp.InformSystem.WebApi.Client.Arguments;
using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Client.Exceptions;
using Informapp.InformSystem.WebApi.Client.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.BearerTokenProviders.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IBearerTokenProvider{T}"/> to ensure an access token is returned
    /// </summary>
    public class EnsureSuccessBearerTokenProviderDecorator<T> : Decorator<IBearerTokenProvider<T>>,
        IBearerTokenProvider<T>

        where T : class
    {
        private readonly IBearerTokenProvider<T> _bearerTokenProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnsureSuccessBearerTokenProviderDecorator{T}"/> class.
        /// </summary>
        /// <param name="bearerTokenProvider">The instance to decorate</param>
        public EnsureSuccessBearerTokenProviderDecorator(
            IBearerTokenProvider<T> bearerTokenProvider) : base(bearerTokenProvider)
        {
            Argument.NotNull(bearerTokenProvider, nameof(bearerTokenProvider));

            _bearerTokenProvider = bearerTokenProvider;
        }

        /// <summary>
        /// Get bearer token and ensure an access token is returned
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The token response</returns>
        public async Task<BearerTokenResponse> GetToken(ApiRequest request, CancellationToken cancellationToken)
        {
            Argument.NotNull(request, nameof(request));

            var tokenResponse = await _bearerTokenProvider.GetToken(request, cancellationToken);

            if (tokenResponse.Response.IsSuccessful != true)
            {
                throw new ApiClientException("Failed to acquire access token");
            }

            return tokenResponse;
        }
    }
}
