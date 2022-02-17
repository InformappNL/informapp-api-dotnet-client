using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Users.ListUser;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Users
{
    internal static class InformAppUserV1Constants
    {
        private const string Route = "api/v1/informapp/users/";

        internal const string ListRoute = Route + "{" + nameof(ListInformAppUserV1Request.BusinessGroupId) + "}";

        // Max length on requests
        internal const int RequestEmailLength = 256;

        // Max length on results
        internal const int ResponseEmailLength = 256;
        internal const int ResponseUserIdLength = 50;

        internal const int PageSizeMaxValue = 100;
    }
}
