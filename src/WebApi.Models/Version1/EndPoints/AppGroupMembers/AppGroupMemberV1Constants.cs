
namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.AppGroupMembers
{
    internal static class AppGroupMemberV1Constants
    {
        private const string Route = "api/v1/appgroups/members";

        internal const string AddRoute = Route;
        internal const string ListRoute = Route;
        internal const string RemoveRoute = Route;



        internal const int PageSizeMaxValue = 100;

        internal const int AddMinItems = 1;
        internal const int AddMaxItems = 10;

        internal const int RemoveMinItems = 1;
        internal const int RemoveMaxItems = 10;
    }
}
