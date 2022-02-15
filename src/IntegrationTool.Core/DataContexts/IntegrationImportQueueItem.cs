using System;

namespace Informapp.InformSystem.IntegrationTool.Core.DataContexts
{
    /// <summary>
    /// Integration import queue item
    /// </summary>
    public class IntegrationImportQueueItem
    {
        /// <summary>
        /// Integration id
        /// </summary>
        public Guid? IntegrationId { get; set; }

        /// <summary>
        /// File
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// File name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// File size
        /// </summary>
        public long? FileSize { get; set; }

        /// <summary>
        /// File date
        /// </summary>
        public DateTimeOffset? FileDate { get; set; }

        /// <summary>
        /// Hash
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// File version id
        /// </summary>
        public Guid? FileVersionId { get; set; }
    }
}
