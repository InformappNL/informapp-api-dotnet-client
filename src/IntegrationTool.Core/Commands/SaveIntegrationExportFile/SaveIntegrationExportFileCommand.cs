using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Informapp.InformSystem.IntegrationTool.Core.Commands.SaveIntegrationExportFile
{
    /// <summary>
    /// Command to save a file received from an export
    /// </summary>
    public class SaveIntegrationExportFileCommand : ICommand<SaveIntegrationExportFileCommandResult>
    {
        /// <summary>
        /// Id of the export
        /// </summary>
        [Required]
        public Guid? IntegrationExportId { get; set; }

        /// <summary>
        /// Stream of the received file
        /// </summary>
        [Required]
        public Stream File { get; set; }

        /// <summary>
        /// Name of the file
        /// </summary>
        [Required]
        public string FileName { get; set; }

        /// <summary>
        /// Size of the file
        /// </summary>
        [Required]
        public long? FileSize { get; set; }

        /// <summary>
        /// Where the file will be saved
        /// </summary>
        [Required]
        public string DestinationFolder { get; set; }

        /// <summary>
        /// Backup folder where a copy of the file that will be replaced will be made
        /// </summary>
        [Required]
        public string BackupFolder { get; set; }

        /// <summary>
        /// If the file can be overwritten this has to be set to true
        /// </summary>
        [Required]
        public bool? Overwrite { get; set; }
    }
}
