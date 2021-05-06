using System.ComponentModel.DataAnnotations;

namespace Informapp.InformSystem.IntegrationTool.Core.Commands.UploadDataSourceFile
{
    /// <summary>
    /// Upload datasource file command result
    /// </summary>
    public class UploadDataSourceFileCommandResult
    {
        /// <summary>
        /// If uploading the file was successful this will have the value Success
        /// </summary>
        [Required]
        public UploadDataSourceFileCommandResultKind? Result { get; set; }
    }
}
