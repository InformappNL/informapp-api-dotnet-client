using System;
using System.IO;

namespace Informapp.InformSystem.WebApi.Models.Version1.Files
{
    /// <summary>
    /// Download file response
    /// </summary>
    public interface IDownloadFileV1Response : IDisposable
    {
        /// <summary>
        /// File name
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// File
        /// </summary>
        Stream File { get; set; }
    }
}
