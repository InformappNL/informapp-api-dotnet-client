using Informapp.InformSystem.IntegrationTool.Core.DataContexts;
using System;
using System.ComponentModel.DataAnnotations;

namespace Informapp.InformSystem.IntegrationTool.Core.IntegrationImports
{
    /// <summary>
    /// Command for initiating the upload of an integration import file
    /// </summary>
    public class UploadIntegrationImportCommand
    {
        public IntegrationImportQueueItem Item { get; set; }

        /// <summary>
        /// Integration Import Id
        /// </summary>
        [Required]
        public Guid? IntegrationImportId { get; set; }
    }
}
