using Informapp.InformSystem.WebApi.Client.Requests;
using RestSharp;

namespace Informapp.InformSystem.WebApi.Client.RestSharp.RequestFactories
{
    /// <summary>
    /// Factory interface to create <see cref="IRestRequest"/> instances
    /// </summary>
    public interface IRequestFactory
    {
        /// <summary>
        /// Create instance of <see cref="IRestRequest"/>
        /// </summary>
        /// <param name="request">The request instance</param>
        /// <returns>The constructed <see cref="IRestRequest"/> instance</returns>
        IRestRequest Create(ApiRequest request);
    }
}
