using System;
using System.IO;

namespace Informapp.InformSystem.IntegrationTool.Core.Uploaders
{
    /// <summary>
    /// Upload command interface
    /// </summary>
    public interface IUploadCommand
    {
        /// <summary>
        /// Stream of the file
        /// </summary>
        Stream File { get; set; }

        /// <summary>
        /// Path of the file
        /// </summary>
        string Path { get; set; }

        /// <summary>
        /// Name of the file
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// Size of the file
        /// </summary>
        long? Size { get; set; }

        /// <summary>
        /// DateTime of when the file was created
        /// </summary>
        DateTime? CreationTimeUtc { get; set; }

        /// <summary>
        /// DateTime of when the file was last written to
        /// </summary>
        DateTime? LastWriteTimeUtc { get; set; }
    }
}
