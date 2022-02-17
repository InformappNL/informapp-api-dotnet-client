using System.ComponentModel.DataAnnotations;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Configurations
{
    /// <summary>
    /// Integration configuration class
    /// </summary>
    public class IntegrationConfiguration
    {
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
