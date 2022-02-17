using System;
using System.IO;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Files
{
    /// <summary>
    /// Download file response
    /// </summary>
    public interface IDownloadFileV1Response : IDisposable
    {
        /// <summary>
        /// Content type
        /// </summary>
        string ContentType { get; set; }

        /// <summary>
        /// File
        /// </summary>
        Stream File { get; set; }

        /// <summary>
        /// File name
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// Size
        /// </summary>
        long? Size { get; set; }
    }
}
