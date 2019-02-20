
namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Forms
{
    internal static class FormV1Constants
    {
        private const string Route = "api/v1/forms";

        internal const string ListRoute = Route;

        // Max length on requests
        internal const int RequestNameLength = 64;
        internal const int RequestDescriptionLength = 64;
        internal const int RequestNumberLength = 36;

        // Max length on results
        internal const int ResponseNameLength = 64 * 2;
        internal const int ResponseDescriptionLength = 64 * 2;
        internal const int ResponseNumberLength = 36 * 2;
    }
}
