using Informapp.InformSystem.WebApi.Client.Caches;

namespace Informapp.InformSystem.WebApi.Client.BearerTokenProviders
{
    /// <summary>
    /// Cache bearer tokens
    /// </summary>
    public interface IBearerTokenCache : ICache<BearerTokenKey, BearerTokenResponse>
    {

    }
}
