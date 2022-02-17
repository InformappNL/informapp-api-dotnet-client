using ConnectedDevelopment.InformSystem.WebApi.Client.Caches;
using RestSharp;
using System;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.RestSharp.ClientFactories
{
    /// <summary>
    /// Cache clients
    /// </summary>
    public interface IClientCache : ICache<Uri, IRestClient>
    {

    }
}
