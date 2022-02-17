using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Configurations
{
    /// <summary>
    /// Cleanup folder configuration class
    /// </summary>
    public class CleanupFolderConfiguration
    {
        /// <summary>
        /// Clean up enabled true/false
        /// </summary>
        [Required]
        public bool? Enabled { get; set; }

        /// <summary>
        /// List of folder to clean up
        /// </summary>
        [Required]
        public IList<CleanupFolderConfigurationFolder> Folders { get; } = new List<CleanupFolderConfigurationFolder>(4);
    }
}
