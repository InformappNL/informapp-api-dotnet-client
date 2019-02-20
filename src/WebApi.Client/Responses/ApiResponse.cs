using System;
using System.Collections.Generic;
using System.Net;

namespace Informapp.InformSystem.WebApi.Client.Responses
{
    /// <summary>
    /// DTO class for API response
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// Elapsed time
        /// </summary>
        public TimeSpan? Elapsed { get; set; }

        /// <summary>
        /// Status code
        /// </summary>
        public HttpStatusCode? StatusCode { get; set; }

        /// <summary>
        /// Response status
        /// </summary>
        public ResponseStatusCode? ResponseStatus { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Content type
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Content model
        /// </summary>
        public object ContentModel { get; set; }

        /// <summary>
        /// Success
        /// </summary>
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// Request id
        /// </summary>
        public Guid? RequestId { get; set; }

        /// <summary>
        /// Total count
        /// </summary>
        public int? TotalCount { get; set; }

        /// <summary>
        /// Headers
        /// </summary>
        public IEnumerable<ResponseHeader> Headers { get; set; }
    }
}
