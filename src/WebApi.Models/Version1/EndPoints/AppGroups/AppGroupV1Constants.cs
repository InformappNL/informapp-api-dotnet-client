using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppGroups.DeleteAppGroup;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppGroups.EditAppGroup;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppGroups.GetAppGroup;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppGroups
{
    internal static class AppGroupV1Constants
    {
        private const string Route = "api/v1/appgroups";

        internal const string CreateRoute = Route;
        internal const string DeleteRoute = Route + "/{" + nameof(DeleteAppGroupV1Request.AppGroupId) + "}";
        internal const string EditRoute = Route + "/{" + nameof(EditAppGroupV1Request.AppGroupId) + "}";
        internal const string GetRoute = Route + "/{" + nameof(GetAppGroupV1Request.AppGroupId) + "}";
        internal const string ListRoute = Route;

        // Max length on requests
        internal const int RequestNameLength = 64;
        internal const int RequestDescriptionLength = 64;

        // Max length on results
        internal const int ResponseNameLength = 64 * 2;
        internal const int ResponseDescriptionLength = 64 * 2;



        internal const int PageSizeMaxValue = 100;
    }
}
