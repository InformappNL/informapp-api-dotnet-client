using System;
using System.ComponentModel.DataAnnotations;

namespace Informapp.InformSystem.IntegrationTool.Core.Configurations
{
    /// <summary>
    /// Datasource configuration for specific datasource
    /// </summary>
    public class DataSourceConfigurationDataSource
    {
        /// <summary>
        /// The description of datasource
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The datasource excel file
        /// Application needs read access to this file
        /// Example "C:\\files\\datasource.xlsx"
        /// This setting is required
        /// </summary>
        [Required]
        public string File { get; set; }

        /// <summary>
        /// The ID of the datasource in InformSystem
        /// Type is GUID
        /// Example "10E5DDEB-ACF7-45D8-82AB-444C78F96E33"
        /// This setting is required
        /// </summary>
        [Required]
        public Guid? DataSourceId { get; set; }

        /// <summary>
        /// Set to true to enable uploading, false to disable (default)
        /// This setting is required
        /// </summary>
        [Required]
        public bool? Enabled { get; set; }
    }
}
