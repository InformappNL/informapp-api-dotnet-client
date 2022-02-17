
namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Customers
{
    internal static class CustomerV1Constants
    {
        private const string Route = "api/v1/customers";

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
    }
}
