using Informapp.InformSystem.WebApi.Client.Caches;
using RestSharp;
using System;

namespace Informapp.InformSystem.WebApi.Client.RestSharp.ClientFactories
{
    /// <summary>
    /// Cache clients
    /// </summary>
    public interface IClientCache : ICache<Uri, IRestClient>
    {

    }
}
