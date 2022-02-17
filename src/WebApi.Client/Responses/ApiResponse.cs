using System;
using System.Net;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Responses
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
        /// Content model
        /// </summary>
        public object ContentModel { get; set; }

        /// <summary>
        /// Success
        /// </summary>
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// Exceptions thrown during the request, if any.
        /// </summary>
        public Exception ErrorException { get; set; }

        /// <summary>
        /// Headers
        /// </summary>
        public ResponseHeaders Headers { get; set; }

        /// <summary>
        /// The download file
        /// </summary>
        public ApiDownloadFileResponse DownloadFile { get; set; }

        /// <summary>
        /// The upload file
        /// </summary>
        public ApiUploadFileResponse UploadFile { get; set; }
    }
}
