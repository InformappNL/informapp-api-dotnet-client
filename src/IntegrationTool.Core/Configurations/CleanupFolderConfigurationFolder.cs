using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Configurations
{
    /// <summary>
    /// Folder configuration for clean up
    /// </summary>
    public class CleanupFolderConfigurationFolder
    {
        /// <summary>
        /// Folder path
        /// </summary>
        [Required]
        public string Folder { get; set; }

        /// <summary>
        /// Cleanup is enabled for this folder true/false
        /// </summary>
        [Required]
        public bool? Enabled { get; set; }

        /// <summary>
        /// Maximum file age
        /// </summary>
        [Range(1, int.MaxValue)]
        [Required]
        public int? MaxAgeInDays { get; set; }

        /// <summary>
        /// List of file extensions that are allowed to be cleaned up
        /// </summary>
        [Required]
        public IList<string> Extensions { get; } = new List<string>(4);
    }
}
