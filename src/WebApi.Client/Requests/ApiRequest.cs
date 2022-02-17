using ConnectedDevelopment.InformSystem.WebApi.Client.Arguments;
using System.Diagnostics;
using System.Globalization;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Requests
{
    /// <summary>
    /// DTO class for API request
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ", nq}")]
    public class ApiRequest
    {
        /// <summary>
        /// The request context
        /// </summary>
        public RequestContext Context { get; set; }

        /// <summary>
        /// Execute anonmymous request
        /// </summary>
        public bool? Anonymous { get; set; }

        /// <summary>
        /// The credentials
        /// </summary>
        public ApiCredentials Credentials { get; set; }

        /// <summary>
        /// The bearer token
        /// </summary>
        public ApiBearerToken BearerToken { get; set; }

        /// <summary>
        /// The response is a file download
        /// </summary>
        public bool? IsFileDownload { get; set; }

        /// <summary>
        /// The request is a file upload
        /// </summary>
        public bool? IsFileUpload { get; set; }

        /// <summary>
        /// The file to upload
        /// </summary>
        public ApiUploadFileRequest UploadFile { get; set; }

        /// <summary>
        /// Create generic <see cref="ApiRequest{T}"/> from request
        /// </summary>
        /// <typeparam name="T">Type of request</typeparam>
        /// <param name="request">The request model</param>
        /// <returns>Request object</returns>
        public static ApiRequest<T> Create<T>(T request)
            where T : class
        {
            Argument.NotNull(request, nameof(request));

            var apiRequest = new ApiRequest<T>
            {
                Model = request
            };

            return apiRequest;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => string.Format(CultureInfo.InvariantCulture,
            "Request: {0} {1}{2}",
            Context?.Method,
            Context?.EndPoint,
            Context?.Path);
    }
}
