using System;
using System.IO;

namespace Informapp.InformSystem.IntegrationTool.Core.Uploaders
{
    /// <summary>
    /// Base class for upload command
    /// </summary>
    public abstract class UploadCommandBase
    {
        /// <summary>
        /// Stream of the file
        /// </summary>
        public Stream File { get; set; }

        /// <summary>
        /// Path of the file
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Name of the file
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Size of the file
        /// </summary>
        public long? Size { get; set; }

        /// <summary>
        /// DateTime of when the file was created
        /// </summary>
        public DateTime? CreationTimeUtc { get; set; }

        /// <summary>
        /// DateTime of when the file was last written to
        /// </summary>
        public DateTime? LastWriteTimeUtc { get; set; }
    }
}
