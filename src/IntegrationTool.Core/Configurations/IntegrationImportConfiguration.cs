using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Informapp.InformSystem.IntegrationTool.Core.Configurations
{
    /// <summary>
    /// Integration import configuration class
    /// </summary>
    public class IntegrationImportConfiguration
    {
        /// <summary>
        /// Integration import is enabled true/false
        /// </summary>
        [Required]
        public bool? Enabled { get; set; }

        /// <summary>
        /// Folder to place files in awaiting upload
        /// </summary>
        [Required]
        public string QueueFolder { get; set; }

        /// <summary>
        /// Folder to move files to after upload
        /// </summary>
        public string DoneFolder { get; set; }

        /// <summary>
        /// List of integration imports
        /// </summary>
        [Required]
        public IList<IntegrationImportConfigurationImport> IntegrationImports { get; }
            = new List<IntegrationImportConfigurationImport>(4);
    }
}
