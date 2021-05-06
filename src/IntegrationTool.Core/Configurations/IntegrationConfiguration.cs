using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Informapp.InformSystem.IntegrationTool.Core.Configurations
{
    /// <summary>
    /// Integration configuration class
    /// </summary>
    public class IntegrationConfiguration
    {
        /// <summary>
        /// Integration is enabled true/false
        /// </summary>
        [Required]
        public bool? Enabled { get; set; }

        /// <summary>
        /// Heartbeat is enabled true/false
        /// </summary>
        [Required]
        public bool? HeartbeatEnabled { get; set; }

        /// <summary>
        /// Drive info upload is enabled true/false
        /// </summary>
        [Required]
        public bool? DriveInfoUploadEnabled { get; set; }

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
        public IntegrationConfigurationDefault Default { get; set; }

        /// <summary>
        /// List of integrations
        /// </summary>
        [Required]
        public IList<IntegrationConfigurationIntegration> Integrations { get; }
            = new List<IntegrationConfigurationIntegration>(4);
    }
}
