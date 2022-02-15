using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Informapp.InformSystem.IntegrationTool.Core.Configurations
{
    /// <summary>
    /// Configuration for non default integration
    /// </summary>
    public class IntegrationExportConfigurationExport : IIntegrationConfiguration
    {
        /// <summary>
        /// Description of the integration
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Integration is enabled true/false
        /// </summary>
        [Required]
        public bool? Enabled { get; set; }

        /// <summary>
        /// Integration Id
        /// </summary>
        [Required]
        public Guid? IntegrationId { get; set; }

        /// <summary>
        /// Folder where the files will be placed after download
        /// </summary>
        [Required]
        public string Folder { get; set; }

        /// <summary>
        /// Backup folder where files will be placed if the file will be overwritten and backup is enabled
        /// </summary>
        [Required]
        public string BackupFolder { get; set; }

        /// <summary>
        /// Overwrite file is enabled true/false
        /// </summary>
        [Required]
        public bool? Overwrite { get; set; }

        /// <summary>
        /// List of allowed extensions
        /// </summary>
        [Required]
        public IList<string> Extensions { get; }
            = new List<string>(4);
    }
}
