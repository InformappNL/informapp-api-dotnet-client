using System.ComponentModel.DataAnnotations;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Commands.CleanupDownloadFolder
{
    /// <summary>
    /// Result after cleanup
    /// </summary>
    public class CleanupDownloadFolderCommandResult
    {
        /// <summary>
        /// If the cleanup was successful this will have the value Success
        /// </summary>
        [Required]
        public CleanupDownloadFolderCommandResultKind? Result { get; set; }

        /// <summary>
        /// The amount of files that were deleted
        /// </summary>
        public int? FilesDeleted { get; set; }

        /// <summary>
        /// The amount of files that were not deleted
        /// </summary>
        public int? FilesNotDeleted { get; set; }
    }
}
