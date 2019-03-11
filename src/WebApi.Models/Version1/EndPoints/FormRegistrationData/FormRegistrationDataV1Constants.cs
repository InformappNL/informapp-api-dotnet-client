
namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationData
{
    internal static class FormRegistrationDataV1Constants
    {
        private const string Route = "api/v1/forms/registrations/data";

        internal const string ListRoute = Route;

        // Max length on requests
        internal const int RequestNameLength = 100;
        internal const int RequestPathLength = 800;
        internal const int RequestTextLength = 10000;

        // Max length on results
        internal const int ResponseNameLength = 100 * 2;
        internal const int ResponseFullNameLength = 800 * 2;
        internal const int ResponsePathLength = 800 * 2;
        internal const int ResponseTextLength = 10000 * 2;


        internal const int PageSizeMaxValue = 100;

        internal const int SerialNumberMin = 1;
        internal const int SerialNumberMax = int.MaxValue;

        internal const int MinDepth = 0;
        internal const int MaxDepth = int.MaxValue;

        internal const int MinIndex = 0;
        internal const int MaxIndex = int.MaxValue;

        internal const int MinOrder = 0;
        internal const int MaxOrder = int.MaxValue;
    }
}
