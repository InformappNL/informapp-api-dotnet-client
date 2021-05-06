using System.ComponentModel.DataAnnotations;

namespace Informapp.InformSystem.IntegrationTool.Core.Commands.MoveFile
{
    /// <summary>
    /// Result after moving the file
    /// </summary>
    public class MoveFileCommandResult
    {
        /// <summary>
        /// If moving the file was successful this will have the value Success
        /// </summary>
        [Required]
        public MoveFileCommandResultKind? Result { get; set; }

        /// <summary>
        /// The amount of files that were overwritten
        /// </summary>
        public bool FileOverwritten { get; set; }

        /// <summary>
        /// The file size of the backup that was made
        /// </summary>
        public long? BackupFileSize { get; set; }
    }
}
