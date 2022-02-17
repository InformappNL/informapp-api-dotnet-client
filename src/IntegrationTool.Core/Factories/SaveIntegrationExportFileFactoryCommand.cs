using System;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Command for the save integration export file factory
    /// </summary>
    public class SaveIntegrationExportFileFactoryCommand
    {
        /// <summary>
        /// Integration export Id
        /// </summary>
        public Guid? IntegrationExportId { get; set; }

        /// <summary>
        /// Folder where the file for the integration will be placed
        /// </summary>
        public string IntegrationFolder { get; set; }

        /// <summary>
        /// Name of the file
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Folder where the backup files for the integration will be placed
        /// </summary>
        public string IntegrationBackupFolder { get; set; }
    }
}
