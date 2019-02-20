using System;

namespace Informapp.InformSystem.WebApi.Client.EndPointProviders
{
    /// <summary>
    /// Interface to provider endpoint for the api
    /// </summary>
    public interface IEndPointProvider
    {
        /// <summary>
        /// Get endpoint
        /// </summary>
        /// <returns>The endpoint</returns>
        Uri GetEndPoint();
    }
}
