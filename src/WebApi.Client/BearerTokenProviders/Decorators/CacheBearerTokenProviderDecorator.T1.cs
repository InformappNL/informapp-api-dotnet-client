using ConnectedDevelopment.InformSystem.WebApi.Client.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Converters;
using ConnectedDevelopment.InformSystem.WebApi.Client.DateTimeProviders;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using ConnectedDevelopment.InformSystem.WebApi.Client.Requests;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.BearerTokenProviders.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IBearerTokenProvider{T}"/> to cache bearer tokens
    /// </summary>
    public class CacheBearerTokenProviderDecorator<T> : Decorator<IBearerTokenProvider<T>>,
        IBearerTokenProvider<T>

        where T : class
    {
        private static readonly TimeSpan minLifetime = TimeSpan.FromMinutes(1);

        private readonly IBearerTokenProvider<T> _bearerTokenProvider;

        private readonly IBearerTokenCache _cache;

        private readonly IDateTimeProvider _dateTimeProvider;

        private readonly IConverter<ApiRequest, BearerTokenKey> _converter;

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheBearerTokenProviderDecorator{T}"/> class.
        /// </summary>
        /// <param name="bearerTokenProvider">The instance to decorate</param>
        /// <param name="cache"></param>
        /// <param name="dateTimeProvider"></param>
        /// <param name="converter"></param>
        public CacheBearerTokenProviderDecorator(
            IBearerTokenProvider<T> bearerTokenProvider,
            IBearerTokenCache cache,
            IDateTimeProvider dateTimeProvider,
            IConverter<ApiRequest, BearerTokenKey> converter) : base(bearerTokenProvider)
        {
            Argument.NotNull(bearerTokenProvider, nameof(bearerTokenProvider));
            Argument.NotNull(cache, nameof(cache));
            Argument.NotNull(dateTimeProvider, nameof(dateTimeProvider));
            Argument.NotNull(converter, nameof(converter));

            _bearerTokenProvider = bearerTokenProvider;

            _cache = cache;

            _dateTimeProvider = dateTimeProvider;

            _converter = converter;
        }

        /// <summary>
        /// Get bearer token, from cache or request new
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The token response</returns>
        public async Task<BearerTokenResponse> GetToken(ApiRequest request, CancellationToken cancellationToken)
        {
            Argument.NotNull(request, nameof(request));

            var key = _converter.Convert(request)
                .ThrowIfNoValue()
                .Value;

            if (_cache.TryGetValue(key, out var tokenResponse) == true)
            {
                var timespan = tokenResponse.Expires - _dateTimeProvider.UtcNow;

                if (timespan < minLifetime)
                {
                    _cache.Remove(key);

                    tokenResponse = null;
                }
            }

            if (tokenResponse == null)
            {
                tokenResponse = await _bearerTokenProvider
                    .GetToken(request, cancellationToken)
                    .ConfigureAwait(Await.Default);

                if (tokenResponse.Response.IsSuccessful == true)
                {
                    _cache.Add(key, tokenResponse);
                }
            }

            return tokenResponse;
        }
    }
}
