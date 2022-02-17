using System.Collections.Generic;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Configurations
{
    /// <summary>
    /// Integration configuration interface
    /// </summary>
    public interface IIntegrationConfiguration
    {
        /// <summary>
        /// Integration is enabled true/false
        /// </summary>
        bool? Enabled { get; }

        /// <summary>
        /// Folder where the integration will put the files
        /// </summary>
        string Folder { get; }

        /// <summary>
        /// Folder where a backup will be placed when a file is overwritten and backup is enabled
        /// </summary>
        string BackupFolder { get; }

        /// <summary>
        /// OVerwriting files is allowed true/false
        /// </summary>
        bool? Overwrite { get; }

        /// <summary>
        /// List of extensions allowed to download/overwrite
        /// </summary>
        IList<string> Extensions { get; }
    }
}
