using System;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Http
{
    /// <summary>
    /// HTTP method override
    /// </summary>
    public static class HttpMethodOverride
    {
        /// <summary>
        /// HTTP method override header name
        /// </summary>
        public const string HeaderName = "X-HTTP-Method-Override";

        /// <summary>
        /// Determine if <see cref="HttpMethod"/> can be overridden
        /// </summary>
        /// <param name="method">The method</param>
        /// <returns>true if overridable, else false.</returns>
        /// <exception cref="ArgumentException"><paramref name="method"/> unsupported value</exception>
        public static bool IsOverridable(HttpMethod method)
        {
            switch (method)
            {
                case HttpMethod.Delete:
                case HttpMethod.Patch:
                case HttpMethod.Put:
                    return true;

                case HttpMethod.Get:
                case HttpMethod.Head:
                case HttpMethod.Post:
                case HttpMethod.Options:
                case HttpMethod.Merge:
                case HttpMethod.Copy:
                    return false;

                default:
                    throw new ArgumentException("Unsupported value", nameof(method));
            }
        }
    }
}
