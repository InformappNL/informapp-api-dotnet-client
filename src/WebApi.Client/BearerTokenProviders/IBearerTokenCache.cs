using ConnectedDevelopment.InformSystem.WebApi.Client.Caches;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.BearerTokenProviders
{
    /// <summary>
    /// Cache bearer tokens
    /// </summary>
    public interface IBearerTokenCache : ICache<BearerTokenKey, BearerTokenResponse>
    {

    }
}
