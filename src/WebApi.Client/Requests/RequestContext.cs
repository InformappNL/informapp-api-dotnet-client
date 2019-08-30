using Informapp.InformSystem.WebApi.Client.DataAnnotations;
using Informapp.InformSystem.WebApi.Models.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;

namespace Informapp.InformSystem.WebApi.Client.Requests
{
    /// <summary>
    /// Request context class
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ", nq}")]
    public class RequestContext
    {
        /// <summary>
        /// The endpoint
        /// </summary>
        [AbsoluteUri]
        [Required]
        public Uri EndPoint { get; set; }

        /// <summary>
        /// The HTTP method
        /// </summary>
        [Required]
        public HttpMethod? Method { get; set; }

        /// <summary>
        /// Use X-HTTP-Method-Override
        /// 
        /// supported for Delete, Head, Patch, and Put
        /// </summary>
        public bool? MethodOverride { get; set; }

        /// <summary>
        /// The path
        /// </summary>
        [RelativeUri]
        [Required]
        public Uri Path { get; set; }

        /// <summary>
        /// The query string
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Content type
        /// </summary>
        public ContentType? ContentType { get; set; }

        /// <summary>
        /// Accept content type
        /// </summary>
        public Accept? Accept { get; set; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture, "Context: {0} {1}{2}", Method, EndPoint, Path);
            }
        }
    }
}
