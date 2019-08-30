using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Models.Http
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
        internal AcceptAttribute(Accept accept)
        {
            switch (accept)
            {
                case Accept.OctetStream:
                    break;
                default:
                    throw new ArgumentException("Unsupported value", nameof(accept));
            }

            Accept = accept;
        }
    }
}
