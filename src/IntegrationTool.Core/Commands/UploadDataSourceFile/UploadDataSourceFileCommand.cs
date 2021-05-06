using System;
using System.ComponentModel.DataAnnotations;

namespace Informapp.InformSystem.IntegrationTool.Core.Commands.UploadDataSourceFile
{
    /// <summary>
    /// Command to initiate uploading a datasource file
    /// </summary>
    public class UploadDataSourceFileCommand : ICommand<UploadDataSourceFileCommandResult>
    {
        /// <summary>
        /// Path of the file that will be uploaded
        /// </summary>
        [Required]
        public string Path { get; set; }

        /// <summary>
        /// DataSource Id
        /// </summary>
        [Required]
        public Guid? DataSourceId { get; set; }
    }
}
