using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppUsers.DeleteAppUser;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppUsers.GetAppUser;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppUsers
{
    internal static class AppUserV1Constants
    {
        private const string Route = "api/v1/appusers";

        internal const string CreateRoute = Route;
        internal const string DeleteRoute = Route + "/{" + nameof(DeleteAppUserV1Request.AppUserId) + "}";
        internal const string GetRoute = Route + "/{" + nameof(GetAppUserV1Request.AppUserId) + "}";
        internal const string ListRoute = Route;

        // Max length on requests
        internal const int RequestEmailLength = 256;

        // Max length on results
        internal const int ResponseEmailLength = 256;



        internal const int PageSizeMaxValue = 100;
    }
}
