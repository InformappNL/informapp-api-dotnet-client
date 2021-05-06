using System.ComponentModel.DataAnnotations;

namespace Informapp.InformSystem.IntegrationTool.Core.Commands.MoveFile
{
    /// <summary>
    /// Command to initiate moving a file
    /// </summary>
    public class MoveFileCommand : ICommand<MoveFileCommandResult>
    {
        /// <summary>
        /// The file that will be moved
        /// </summary>
        [Required]
        public string Source { get; set; }

        /// <summary>
        /// The destination of the source file
        /// </summary>
        [Required]
        public string Destination { get; set; }

        /// <summary>
        /// If a backup has to be made when replacing a file, this needs to be set to true
        /// </summary>
        [Required]
        public bool? BackupIsRequired
        {
            get
            {
                if (string.IsNullOrEmpty(Backup) && Overwrite != true)
                {
                    return null;
                }
                return true;
            }
        }

        /// <summary>
        /// Where the backup will be placed
        /// </summary>
        public string Backup { get; set; }

        /// <summary>
        /// If the file can be overwritten this has to be set to true
        /// </summary>
        [Required]
        public bool? Overwrite { get; set; }
    }
}
