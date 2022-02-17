using System;
using System.ComponentModel.DataAnnotations;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Configurations
{
    /// <summary>
    /// Integration import configuration for specific import
    /// </summary>
    public class IntegrationImportConfigurationImport : IIntegrationImportConfiguration
    {
        /// <summary>
        /// The ID of the integration in InformSystem
        /// Type is GUID
        /// Example "10E5DDEB-ACF7-45D8-82AB-444C78F96E33"
        /// This setting is required
        /// </summary>
        [Required]
        public Guid? IntegrationId { get; set; }

        /// <summary>
        /// The description of integration import
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Set to true to enable uploading, false to disable (default)
        /// This setting is required
        /// </summary>
        [Required]
        public bool? Enabled { get; set; }

        /// <summary>
        /// The integration import excel file
        /// Application needs read access to this file
        /// Example "C:\\files\\integration import.xlsx"
        /// This setting is required
        /// </summary>
        [Required]
        public string File { get; set; }

        /// <summary>
        /// Set to true to move the source file to the queue folder,
        /// Set to false to leave the original file and place a copy in the queue folder 
        /// </summary>
        [Required]
        public bool? MoveFile { get; set; }
    }
}
