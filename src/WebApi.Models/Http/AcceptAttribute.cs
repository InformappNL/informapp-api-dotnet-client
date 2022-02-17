using System;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Http
{
    /// <summary>
    /// Indicates the content type to use in ACCEPT header for a request
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class AcceptAttribute : Attribute
    {
        /// <summary>
        /// Content type to accept
        /// </summary>
        public Accept Accept { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AcceptAttribute"/> class.
        /// </summary>
        public AcceptAttribute(Accept accept)
        {
            switch (accept)
            {
                case Accept.OctetStream:
                    break;
                case Accept.Json:
                    throw new ArgumentException("Unsupported value", nameof(accept));
                default:
                    throw new ArgumentException("Unsupported value", nameof(accept));
            }

            Accept = accept;
        }
    }
}
