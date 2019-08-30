
namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Logs
{
    internal static class LogV1Constants
    {
        internal const string Route = "api/v1/logs";

        internal const string CreateRoute = Route;

        internal const int RequestThreadLength = 255;
        internal const int RequestNameLength = 512;
        internal const int RequestMessageLength = 16000;
        internal const int RequestExceptionLength = 16000;
    }
}
