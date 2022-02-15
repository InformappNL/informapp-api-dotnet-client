using System;

namespace Informapp.InformSystem.IntegrationTool.Core.Configurations
{
    /// <summary>
    /// Integration import configuration interface
    /// </summary>
    public interface IIntegrationImportConfiguration
    {
        /// <summary>
        /// Integration id
        /// </summary>
        Guid? IntegrationId { get; }

        /// <summary>
        /// Description
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Enabled
        /// </summary>
        bool? Enabled { get; }

        /// <summary>
        /// File
        /// </summary>
        string File { get; }
    }
}
