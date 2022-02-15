#pragma warning disable //CA1716 Rename namespace
namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Imports
#pragma warning restore //CA1716 Rename namespace
{
    /// <summary>
    /// Integration import constants
    /// </summary>
    public static class IntegrationImportV1Constants
    {
        private const string Route = "/api/v1/integrations/imports";

        internal const string StartRoute = Route + "/start";
        internal const string UploadRoute = Route + "/files/{" + nameof(UploadIntegrationImportV1Request.IntegrationImportId) + "}";
        internal const string ReportRoute = Route + "/report/{" + nameof(ReportIntegrationImportV1Request.IntegrationImportId) + "}";

        internal const int PageSizeMaxValue = 100;

        internal const int MinAttemptNumber = 1;
        internal const int MaxAttemptNumber = int.MaxValue;

        internal const int MinDurationNumber = 0;
        internal const int MaxDurationNumber = int.MaxValue;

        internal const int MessageLength = 2048;

        /// <summary>
        /// Maximum length for exception
        /// </summary>
        public const int ExceptionLength = 16000;

        internal const int MaxFileNameLength = 2 * 260;
    }
}
