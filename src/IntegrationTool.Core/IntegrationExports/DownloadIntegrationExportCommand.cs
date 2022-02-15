using Informapp.InformSystem.IntegrationTool.Core.Configurations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Informapp.InformSystem.IntegrationTool.Core.IntegrationExports
{
    /// <summary>
    /// Command for initiating the download of an integration export file
    /// </summary>
    public class DownloadIntegrationExportCommand
    {
        /// <summary>
        /// Integration Export Id
        /// </summary>
        [Required]
        public Guid? IntegrationExportId { get; set; }

        /// <summary>
        /// Integration Id
        /// </summary>
        [Required]
        public Guid? IntegrationId { get; set; }

        /// <summary>
        /// The name of the file
        /// </summary>
        [Required]
        public string FileName { get; set; }

        /// <summary>
        /// Integration Export Log Id
        /// </summary>
        [Required]
        public Guid? IntegrationExportLogId { get; set; }

        /// <summary>
        /// Interface for the configuration of the download tool
        /// </summary>
        [Required]
        public IIntegrationConfiguration Configuration { get; set; }

        /// <summary>
        /// Accept the download true/false
        /// </summary>
        [Required]
        public bool? Accept { get; set; }
    }
}
