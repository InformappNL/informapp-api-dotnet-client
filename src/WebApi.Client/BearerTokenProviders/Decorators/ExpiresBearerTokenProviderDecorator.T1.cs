using Informapp.InformSystem.WebApi.Client.Arguments;
using Informapp.InformSystem.WebApi.Client.DateTimeProviders;
using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Requires;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.BearerTokenProviders.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IBearerTokenProvider{T}"/> to adjust expiration of bearer tokens to our idea of time
    /// </summary>
    public class ExpiresBearerTokenProviderDecorator<T> : Decorator<IBearerTokenProvider<T>>,
        IBearerTokenProvider<T>

        where T : class
    {
        private readonly IBearerTokenProvider<T> _bearerTokenProvider;

        private readonly IDateTimeProvider _dateTimeProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpiresBearerTokenProviderDecorator{T}"/> class.
        /// </summary>
        /// <param name="bearerTokenProvider">The instance to decorate</param>
        /// <param name="dateTimeProvider"></param>
        public ExpiresBearerTokenProviderDecorator(
            IBearerTokenProvider<T> bearerTokenProvider,
            IDateTimeProvider dateTimeProvider) : base(bearerTokenProvider)
        {
            Argument.NotNull(bearerTokenProvider, nameof(bearerTokenProvider));
            Argument.NotNull(dateTimeProvider, nameof(dateTimeProvider));

            _bearerTokenProvider = bearerTokenProvider;

            _dateTimeProvider = dateTimeProvider;
        }

        /// <summary>
        /// Get bearer token and adjust expiration of bearer tokens to our idea of time
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The token response</returns>
        public async Task<BearerTokenResponse> GetToken(ApiRequest request, CancellationToken cancellationToken)
        {
            Argument.NotNull(request, nameof(request));

            var tokenResponse = await _bearerTokenProvider
                .GetToken(request, cancellationToken)
                .ConfigureAwait(Await.Default);

            if (tokenResponse.Response.IsSuccessful == true)
            {
                double? expiresIn = tokenResponse.ExpiresIn;

                Require.NotNull(expiresIn, nameof(expiresIn));

                // Lower expiration to reduce the chance of using an expired token
                expiresIn = expiresIn * 0.9D;

                var now = _dateTimeProvider.UtcNow;

                var expires = now.AddSeconds(expiresIn.Value);

                tokenResponse.Expires = expires;
            }

            return tokenResponse;
        }
    }
}
