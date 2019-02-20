using Informapp.InformSystem.WebApi.Client.Requests;
using RestSharp;

namespace Informapp.InformSystem.WebApi.Client.RestSharp.ClientFactories
{
    /// <summary>
    /// Factory interface to create instances of <see cref="IRestClient"/>
    /// </summary>
    public interface IClientFactory
    {
        /// <summary>
        /// Create instance of <see cref="IRestClient"/>
        /// </summary>
        /// <param name="request">The request to create a client for</param>
        /// <returns>The created instance of <see cref="IRestClient"/></returns>
        IRestClient Create(ApiRequest request);
    }
}
