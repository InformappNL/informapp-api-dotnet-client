using System;
using System.IO;

namespace Informapp.InformSystem.WebApi.Models.Version1.Files
{
    /// <summary>
    /// Upload file request
    /// </summary>
    public interface IUploadFileV1Request : IDisposable
    {
        /// <summary>
        /// ContentType
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
