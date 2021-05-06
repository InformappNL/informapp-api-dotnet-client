using System;

namespace Informapp.InformSystem.IntegrationTool.Core.Uploaders.DataSourceFiles
{
    /// <summary>
    /// Command to initiate datasource file upload
    /// </summary>
    public class DataSourceFileUploadCommand : UploadCommandBase,
        IUploadCommand
    {
        /// <summary>
        /// Datasource Id
        /// </summary>
        public Guid? DataSourceId { get; set; }
    }
}
