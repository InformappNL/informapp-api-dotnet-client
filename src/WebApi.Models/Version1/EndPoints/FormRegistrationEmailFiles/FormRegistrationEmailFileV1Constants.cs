using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationEmailFiles.Download;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationEmailFiles
{
    internal static class FormRegistrationEmailFileV1Constants
    {
        private const string Route = "/api/v1/forms/registrations/emails/files";

        internal const string DownloadRoute = Route + "/{" + nameof(DownloadFormRegistrationEmailFileV1Request.FormRegistrationEmailFileId) + "}";
    }
}
