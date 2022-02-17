using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.DataSources.DownloadDataSource;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.DataSources.UploadDataSource;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.DataSources
{
    internal static class DataSourceV1Constants
    {
        private const string Route = "api/v1/datasources";

        internal const string DownloadRoute = Route + "/file/{" + nameof(DownloadDataSourceV1Request.DataSourceId) + "}";
        internal const string ListRoute = Route;
        internal const string UploadRoute = Route + "/file/{" + nameof(UploadDataSourceV1Request.DataSourceId) + "}";

        // Max length on requests
        internal const int RequestNameLength = 64;
        internal const int RequestDescriptionLength = 64;

        // Max length on results
        internal const int ResponseNameLength = 64 * 2;
        internal const int ResponseDescriptionLength = 64 * 2;



        internal const int PageSizeMaxValue = 100;
    }
}
