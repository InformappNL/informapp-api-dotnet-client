namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Result for save integration export file factory
    /// </summary>
    public class SaveIntegrationExportFileFactoryCommandResult
    {
        /// <summary>
        /// Path where the file will be downloaded
        /// </summary>
        public string DownloadPath { get; set; }

        /// <summary>
        /// Name of the file that will be downloaded
        /// </summary>
        public string DownloadFileName { get; set; }

        /// <summary>
        /// Folder where the file will be downloaded
        /// </summary>
        public string DownloadFolder { get; set; }

        /// <summary>
        /// Path of the integration export file
        /// </summary>
        public string IntegrationPath { get; set; }

        /// <summary>
        /// Path of the backup file
        /// </summary>
        public string BackupPath { get; set; }

        /// <summary>
        /// Name of the backup file
        /// </summary>
        public string BackupFileName { get; set; }
    }
}
