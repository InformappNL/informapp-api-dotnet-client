
namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Countries
{
    internal static class CountryV1Constants
    {
        internal const string Route = "api/v1/countries";

        internal const string ListRoute = Route;

        // Max length on requests
        internal const int RequestNameLength = 64;

        // Max length on results
        internal const int ResponseNameLength = 64 * 2;

        internal const int Alpha2CodeLength = 2;

        internal const int Alpha3CodeLength = 3;

        internal const int MaxNumericCode = 999;
        internal const int MinNumericCode = 0;

        internal const int NumberOfCountries = 249;
    }
}
