using System.IO;

namespace Informapp.InformSystem.WebApi.Client.Responses
{
    /// <summary>
    /// Api download file response
    /// </summary>
    public class ApiDownloadFileResponse
    {
        /// <summary>
        /// The file
        /// </summary>
        public Stream File { get; set; }

        /// <summary>
        /// The filename
        /// </summary>
        public string FileName { get; set; }
    }
}
