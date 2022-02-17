using System.ComponentModel.DataAnnotations;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Commands.SaveIntegrationExportFile
{
    /// <summary>
    /// Result after saving the file
    /// </summary>
    public class SaveIntegrationExportFileCommandResult
    {
        /// <summary>
        /// If saving the file was successful this will have the value Success
        /// </summary>
        [Required]
        public SaveIntegrationExportFileCommandResultKind? Result { get; set; }

        /// <summary>
        /// The amount of files that were overwritten
        /// </summary>
        public bool? FileOverwritten { get; set; }

        /// <summary>
        /// The file name of the backup that was made
        /// </summary>
        public string BackupFileName { get; set; }

        /// <summary>
        /// The file size of the backup that was made
        /// </summary>
        public long? BackupFileSize { get; set; }
    }
}
