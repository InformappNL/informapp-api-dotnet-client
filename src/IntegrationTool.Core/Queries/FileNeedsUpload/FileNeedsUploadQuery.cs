using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Informapp.InformSystem.IntegrationTool.Core.Queries.FileNeedsUpload
{
    /// <summary>
    /// Query to check if a file needs to be uploaded
    /// </summary>
    public class FileNeedsUploadQuery : IQuery<FileNeedsUploadQueryResult>
    {
        /// <summary>
        /// Stream of the file
        /// </summary>
        [Required]
        public Stream File { get; set; }

        /// <summary>
        /// Path of the file
        /// </summary>
        [Required]
        public string Path { get; set; }

        /// <summary>
        /// Name of the file
        /// </summary>
        [Required]
        public string FileName { get; set; }

        /// <summary>
        /// Size of the files
        /// </summary>
        [Required]
        public long? Size { get; set; }

        /// <summary>
        /// DateTime when file was created
        /// </summary>
        [Required]
        public DateTime? CreationTimeUtc { get; set; }

        /// <summary>
        /// DateTime when file was last written to
        /// </summary>
        [Required]
        public DateTime? LastWriteTimeUtc { get; set; }
    }
}
