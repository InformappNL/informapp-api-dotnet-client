using System.ComponentModel.DataAnnotations;
using System.IO;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Commands.WriteFileFromStreams
{
    /// <summary>
    /// Command to initiate writing a file from a stream
    /// </summary>
    public class WriteFileFromStreamCommand : ICommand<WriteFileFromStreamCommandResult>
    {
        /// <summary>
        /// The path where the file will be written
        /// </summary>
        [Required]
        public string Path { get; set; }

        /// <summary>
        /// Name of the file
        /// </summary>
        [Required]
        public string FileName { get; set; }

        /// <summary>
        /// Stream of the file
        /// </summary>
        [Required]
        public Stream File { get; set; }

        /// <summary>
        /// Size of the file
        /// </summary>
        [Range(0L, long.MaxValue)]
        [Required]
        public long? Size { get; set; }
    }
}
