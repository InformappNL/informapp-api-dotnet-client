﻿using System;

namespace Informapp.InformSystem.IntegrationTool.Core.IO
{
    /// <summary>
    /// File model class
    /// </summary>
    public class FileModel
    {
        /// <summary>
        /// If upload is needed for the file this will be true
        /// </summary>
        public bool? UploadNeeded { get; set; }

        /// <summary>
        /// The path of the file
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Date time offset when the file was last uploaded
        /// </summary>
        public DateTimeOffset? LastUploadDate { get; set; }

        /// <summary>
        /// Size of the file
        /// </summary>
        public long? Size { get; set; }

        /// <summary>
        /// Hash of the file
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// Date time when the file was created in UTC
        /// </summary>
        public DateTime? CreationTimeUtc { get; set; }

        /// <summary>
        /// Date time when the file was last written to in UTC
        /// </summary>
        public DateTime? LastWriteTimeUtc { get; set; }

        /// <summary>
        /// Date time offset when hash check was last done
        /// </summary>
        public DateTimeOffset? LastHashCheckDate { get; set; }

        /// <summary>
        /// Amount of upload attempts
        /// </summary>
        public int? Attempts { get; set; }
    }
}
