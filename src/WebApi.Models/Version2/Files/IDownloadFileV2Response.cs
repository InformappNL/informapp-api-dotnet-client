using System;
using System.IO;

namespace Informapp.InformSystem.WebApi.Models.Version2.Files
{
    /// <summary>
    /// Download file response
    /// </summary>
    public interface IDownloadFileV2Response : IDisposable
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
