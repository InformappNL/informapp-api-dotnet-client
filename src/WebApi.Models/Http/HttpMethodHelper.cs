using System;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Http
{
    /// <summary>
    /// Static helper class for <see cref="HttpMethod"/>
    /// </summary>
    public static class HttpMethodHelper
    {
        /// <summary>
        /// Determine if a <see cref="HttpMethod"/> has a request body
        /// </summary>
        /// <param name="method">The method</param>
        /// <returns>true if the method has a request body; else false</returns>
        public static bool HasRequestBody(HttpMethod method)
        {
            switch (method)
            {
                case HttpMethod.Copy:
                case HttpMethod.Get:
                case HttpMethod.Head:
                case HttpMethod.Options:
                    return false;
                case HttpMethod.Delete:
                case HttpMethod.Merge:
                case HttpMethod.Patch:
                case HttpMethod.Post:
                case HttpMethod.Put:
                    return true;
                default:
                    throw new ArgumentException("Unsupported value", nameof(method));
            }
        }
    }
}
