using System.IO;

namespace Informapp.InformSystem.WebApi.Client.Requests
{
    /// <summary>
    /// Api upload file request
    /// </summary>
    public class ApiUploadFileRequest
    {
        /// <summary>
        /// The Content-Type
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// The file to upload
        /// </summary>
        public Stream File { get; set; }

        /// <summary>
        /// The filename
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The parameter name of the file in the api request
        /// </summary>
        public string FileParameterName { get; set; }
    }
}
