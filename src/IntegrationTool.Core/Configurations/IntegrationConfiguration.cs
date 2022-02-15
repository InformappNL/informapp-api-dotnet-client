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
    }
}
