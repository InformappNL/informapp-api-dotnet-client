using ConnectedDevelopment.InformSystem.WebApi.Client.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Responses
{
    /// <summary>
    /// Collection of response headers
    /// </summary>
    public class ResponseHeaders
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseHeaders"/> class.
        /// </summary>
        /// <param name="headers">The response headers</param>
        public ResponseHeaders(
            IEnumerable<ResponseHeader> headers)
        {
            Argument.NotNull(headers, nameof(headers));

            Headers = headers;
        }

        /// <summary>
        /// Get header by name
        /// </summary>
        /// <param name="headerName">The header name</param>
        /// <returns>The response header, null of not found</returns>
        public ResponseHeader GetHeader(string headerName)
        {
            Argument.NotNullOrEmpty(headerName, nameof(headerName));

            var header = Headers
                .Where(x => string.Equals(headerName, x.Name, StringComparison.OrdinalIgnoreCase))
                .SingleOrDefault();

            return header;
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

        /// <summary>
        /// Content-Disposition
        /// </summary>
        public ContentDispositionHeader ContentDisposition { get; set; }
    }
}
