
namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.BusinessGroups
{
    internal static class BusinessGroupV1Constants
    {
        private const string Route = "api/v1/businessgroups";

        internal const string ListRoute = Route;

        // Max length on requests
        internal const int RequestNameLength = 64;
        internal const int RequestDescriptionLength = 64;
        internal const int RequestNumberLength = 36;

        // Max length on results
        internal const int ResponseNameLength = 64 * 2;
        internal const int ResponseDescriptionLength = 64 * 2;
        internal const int ResponseNumberLength = 36 * 2;



        internal const int PageSizeMaxValue = 100;

        internal const int TotalRegistrationCountMin = 0;
        internal const int TotalRegistrationCountMax = int.MaxValue;

        internal const int CurrentCreditLeftMin = 0;
        internal const int CurrentCreditLeftMax = int.MaxValue;

        internal const int CurrentCreditTotalMin = 0;
        internal const int CurrentCreditTotalMax = int.MaxValue;

        internal const int TotalCreditMin = 0;
        internal const int TotalCreditMax = int.MaxValue;

        internal const int PendingCreditCountMin = 0;
        internal const int PendingCreditCountMax = int.MaxValue;
    }
}
