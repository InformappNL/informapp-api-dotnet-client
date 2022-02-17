using ConnectedDevelopment.InformSystem.WebApi.Client.Caches;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.BearerTokenProviders
{
    /// <summary>
    /// Cache bearer tokens
    /// </summary>
    public class BearerTokenCache : CacheBase<BearerTokenKey, BearerTokenResponse>,
        IBearerTokenCache
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BearerTokenCache"/> class.
        /// </summary>
        /// <param name="cache">The cache instance to use</param>
        public BearerTokenCache(
            ICache<BearerTokenKey, BearerTokenResponse> cache) : base(cache)
        {

        }
    }
}
