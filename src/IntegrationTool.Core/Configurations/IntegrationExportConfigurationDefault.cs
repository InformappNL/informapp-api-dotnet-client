using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Configurations
{
    /// <summary>
    /// Default configuration for integration
    /// </summary>
    public class IntegrationExportConfigurationDefault : IIntegrationConfiguration
    {
        /// <summary>
        /// Default configuration is enabled true/false
        /// </summary>
        [Required]
        public bool? Enabled { get; set; }

        /// <summary>
        /// Default folder for integration
        /// </summary>
        [Required]
        public string Folder { get; set; }

        /// <summary>
        /// Default backup folder for integration
        /// </summary>
        [Required]
        public string BackupFolder { get; set; }

        /// <summary>
        /// Default overwrite files is enabled true/false
        /// </summary>
        [Required]
        public bool? Overwrite { get; set; }

        /// <summary>
        /// List of allowed extentions for default integration
        /// </summary>
        [Required]
        public IList<string> Extensions { get; }
            = new List<string>(4);
    }
}
