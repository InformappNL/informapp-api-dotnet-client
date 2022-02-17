
namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormDataNames
{
    internal static class FormDataNameV1Constants
    {
        private const string Route = "api/v1/forms/datanames";

        internal const string ListRoute = Route + "/{" + nameof(ListFormDataNameV1Request.FormId) + "}";

        internal const int ResponseNameLength = 100 * 2;
        internal const int ResponseFullNameLength = 800 * 2;

        internal const int PageSizeMaxValue = 100;

        internal const int MinDepth = 0;
        internal const int MaxDepth = int.MaxValue;
    }
}
