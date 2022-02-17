using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Configurations
{
    /// <summary>
    /// Integration configuration class
    /// </summary>
    public class IntegrationExportConfiguration
    {
        /// <summary>
        /// Integration is enabled true/false
        /// </summary>
        [Required]
        public bool? Enabled { get; set; }

        /// <summary>
        /// Path where the files will be downloaded
        /// </summary>
        [Required]
        public string DownloadFolder { get; set; }

        /// <summary>
        /// Cleanup download folder is enabled true/false
        /// </summary>
        [Required]
        public bool? CleanDownloadFolder { get; set; }

        /// <summary>
        /// Default values for the integration
        /// </summary>
        [Required]
        public IntegrationExportConfigurationDefault Default { get; set; }

        /// <summary>
        /// List of integrations
        /// </summary>
        [Required]
        public IList<IntegrationExportConfigurationExport> IntegrationExports { get; }
            = new List<IntegrationExportConfigurationExport>(4);
    }
}
