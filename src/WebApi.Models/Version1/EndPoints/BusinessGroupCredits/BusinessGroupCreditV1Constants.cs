
namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.BusinessGroupCredits
{
    internal static class BusinessGroupCreditV1Constants
    {
        private const string Route = "api/v1/businessgroup/credits";

        internal const string ListRoute = Route;



        internal const int PageSizeMaxValue = 100;

        internal const int TotalRegistrationCountMin = 0;
        internal const int TotalRegistrationCountMax = int.MaxValue;

        internal const int TotalAvailableCreditsMin = 0;
        internal const int TotalAvailableCreditsMax = int.MaxValue;

        internal const int TotalCreditsOfNonEmptyBundlesMin = 0;
        internal const int TotalCreditsOfNonEmptyBundlesMax = int.MaxValue;

        internal const int TotalCreditsMin = 0;
        internal const int TotalCreditsMax = int.MaxValue;

        internal const int TotalPendingCreditsMin = 0;
        internal const int TotalPendingCreditsMax = int.MaxValue;
    }
}
