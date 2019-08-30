using Informapp.InformSystem.WebApi.Client.AttributeProviders;
using Informapp.InformSystem.WebApi.Models.Http;
using System;

namespace Informapp.InformSystem.WebApi.Client.MethodProviders
{
    /// <summary>
    /// Retrieve method from a class
    /// </summary>
    /// <typeparam name="T">Type to get method from</typeparam>
    public class MethodProvider<T> : IMethodProvider<T>
        where T : class
    {
        private static readonly HttpMethodAttribute _attribute = AttributeProvider.Create<T, HttpMethodAttribute>(inherit: true)
            .ThrowIfMultiple()
            .Attribute;

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodProvider{T}"/> class.
        /// </summary>
        /// <exception cref="InvalidOperationException"><typeparamref name="T"/> is missing <see cref="HttpMethodAttribute"/></exception>
        public MethodProvider()
        {
            if (_attribute == null)
            {
                string message = typeof(T).Name + " is missing attribute " + nameof(HttpMethodAttribute);

                throw new InvalidOperationException(message);
            }
        }

        /// <summary>
        /// Get method
        /// </summary>
        /// <returns>The method</returns>
        public HttpMethod? GetMethod()
        {
            return _attribute.Method;
        }
    }
}
