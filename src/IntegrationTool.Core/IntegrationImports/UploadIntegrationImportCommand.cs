using Informapp.InformSystem.IntegrationTool.Core.DataContexts;
using System;
using System.ComponentModel.DataAnnotations;

namespace Informapp.InformSystem.IntegrationTool.Core.IntegrationImports
{
    /// <summary>
    /// Upload integration import command
    /// </summary>
    public class UploadIntegrationImportCommand
    {
        /// <summary>
        /// Item
        /// </summary>
        public IntegrationImportQueueItem Item { get; set; }

        /// <summary>
        /// Integration import id
        /// </summary>
        [Required]
        public Guid? IntegrationImportId { get; set; }
    }
}
