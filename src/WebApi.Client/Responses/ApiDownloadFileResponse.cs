using System.IO;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Responses
{
    /// <summary>
    /// Api download file response
    /// </summary>
    public class ApiDownloadFileResponse
    {
        /// <summary>
        /// Content type
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// File
        /// </summary>
        public Stream File { get; set; }

        /// <summary>
        /// File name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Size
        /// </summary>
        public long? Size { get; set; }
    }
}
