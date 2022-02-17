using System;
using System.IO;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Queries.CreateStreamFromPath
{
    /// <summary>
    /// Result after making a stream from the provided file
    /// </summary>
    public sealed class CreateStreamFromPathQueryResult : IDisposable
    {
        /// <summary>
        /// Stream of the file
        /// </summary>
        public Stream File { get; set; }

        /// <summary>
        /// Name of the file
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Path of the file
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Size of the file
        /// </summary>
        public long? Size { get; set; }

        /// <summary>
        /// When the stream was created
        /// </summary>
        public DateTime? CreationTimeUtc { get; set; }

        /// <summary>
        /// Last time the file was written to
        /// </summary>
        public DateTime? LastWriteTimeUtc { get; set; }

        /// <summary>
        /// Dispose the file
        /// </summary>
        public void Dispose()
        {
            if (File != null)
            {
                File.Dispose();
            }
        }
    }
}
