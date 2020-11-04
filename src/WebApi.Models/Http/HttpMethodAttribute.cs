using System;

namespace Informapp.InformSystem.WebApi.Models.Http
{
    /// <summary>
    /// Specify http method for a request class
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public sealed class HttpMethodAttribute : Attribute
    {
        /// <summary>
        /// HTTP method
        /// </summary>
        public HttpMethod Method { get; }

        /// <summary>
        /// Create instance with the specified HTTP method
        /// </summary>
        /// <param name="method">HTTP method</param>
        /// <exception cref="ArgumentException"><paramref name="method"/> unsupported value</exception>
        public HttpMethodAttribute(HttpMethod method)
        {
            switch (method)
            {
                case HttpMethod.Get:
                case HttpMethod.Post:
                case HttpMethod.Put:
                case HttpMethod.Delete:
                case HttpMethod.Head:
                case HttpMethod.Options:
                case HttpMethod.Patch:
                case HttpMethod.Merge:
                case HttpMethod.Copy:
                    break;
                default:
                    throw new ArgumentException("Unsupported value", nameof(method));
            }

            Method = method;
        }
    }
}
