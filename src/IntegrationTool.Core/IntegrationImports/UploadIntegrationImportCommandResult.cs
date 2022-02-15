using System;

namespace Informapp.InformSystem.IntegrationTool.Core.IntegrationImports
{
    /// <summary>
    /// Result after uploading integration import
    /// </summary>
    public class UploadIntegrationImportCommandResult
    {
        /// <summary>
        /// If the upload was successful this will be true
        /// </summary>
        public bool? Success { get; set; }

        /// <summary>
        /// If something happend like an exception it will be logged here
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// If an exception was thrown it will be logged here
        /// </summary>
        public Exception Exception { get; set; }
    }
}
