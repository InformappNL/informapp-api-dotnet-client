using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationAttachments.Download;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationAttachments
{
    internal static class FormRegistrationAttachmentV1Constants
    {
        private const string Route = "/api/v1/forms/registrations/attachments";

        internal const string DownloadRoute = Route + "/{" + nameof(DownloadFormRegistrationAttachmentV1Request.FormRegistrationAttachmentId) + "}";
    }
}
