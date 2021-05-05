
namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Exports
{
    internal static class IntegrationExportV1Constants
    {
        private const string Route = "/api/v1/integrations/exports";

        internal const string AcceptRoute = Route + "/accept/{" + nameof(AcceptIntegrationExportV1Request.IntegrationExportId) + "}";
        internal const string DownloadRoute = Route + "/files/{" + nameof(DownloadIntegrationExportV1Request.IntegrationExportId) + "}";
        internal const string ListQueuedForMeRoute = Route + "/queued/me";
        internal const string RejectRoute = Route + "/reject/{" + nameof(RejectIntegrationExportV1Request.IntegrationExportId) + "}";
        internal const string ReportRoute = Route + "/report/{" + nameof(ReportIntegrationExportV1Request.IntegrationExportId) + "}";

        internal const int PageSizeMaxValue = 100;

        internal const int MinAttemptNumber = 1;
        internal const int MaxAttemptNumber = int.MaxValue;

        internal const int MinDurationNumber = 0;
        internal const int MaxDurationNumber = int.MaxValue;

        internal const int MessageLength = 2048;
        internal const int ExceptionLength = 16000;

        internal const int MaxFileNameLength = 2 * 260;
    }
}
