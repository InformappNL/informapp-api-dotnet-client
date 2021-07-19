using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationAttachments.Download;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationEmailFiles
{
    internal static class FormRegistrationEmailFileV1Constants
    {
        private const string Route = "/api/v1/forms/registrations/emails/files";

        internal const string DownloadRoute = Route + "/{" + nameof(DownloadFormRegistrationAttachmentV1Request.FormRegistrationAttachmentId) + "}";
    }
}
