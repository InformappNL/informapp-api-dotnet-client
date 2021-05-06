using System.ComponentModel.DataAnnotations;

namespace Informapp.InformSystem.IntegrationTool.Core.Commands.WriteFileFromStreams
{
    /// <summary>
    /// Result after write file command has been executed
    /// </summary>
    public class WriteFileFromStreamCommandResult
    {
        /// <summary>
        /// If writing the file was successful this will have the value Success
        /// </summary>
        [Required]
        public WriteFileFromStreamCommandResultKind? Result { get; set; }

        /// <summary>
        /// Amount of bytes written
        /// </summary>
        public long? BytesWritten { get; set; }
    }
}
