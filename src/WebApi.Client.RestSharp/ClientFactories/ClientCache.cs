using Informapp.InformSystem.WebApi.Client.Caches;
using RestSharp;
using System;

namespace Informapp.InformSystem.WebApi.Client.RestSharp.ClientFactories
{
    /// <summary>
    /// Cache clients
    /// </summary>
    public class ClientCache : CacheBase<Uri, IRestClient>,
        IClientCache
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientCache"/> class.
        /// </summary>
        /// <param name="cache">The cache instance to use</param>
        public ClientCache(
            ICache<Uri, IRestClient> cache) : base(cache)
        {

        }
    }
}
