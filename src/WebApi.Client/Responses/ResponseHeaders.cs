using Informapp.InformSystem.WebApi.Client.Arguments;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Responses
{
    /// <summary>
    /// Collection of response headers
    /// </summary>
    public class ResponseHeaders
    {
        public ResponseHeaders(
            IEnumerable<ResponseHeader> headers)
        {
            Argument.NotNull(headers, nameof(headers));

            Headers = headers;
        }

        /// <summary>
        /// Headers
        /// </summary>
        public IEnumerable<ResponseHeader> Headers { get; }

        /// <summary>
        /// Content-Length
        /// </summary>
        public long ContentLength { get; set; }

        /// <summary>
        /// Content-Type
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Request Id
        /// </summary>
        public Guid? RequestId { get; set; }

        /// <summary>
        /// Total count
        /// </summary>
        public int? TotalCount { get; set; }
    }
}
