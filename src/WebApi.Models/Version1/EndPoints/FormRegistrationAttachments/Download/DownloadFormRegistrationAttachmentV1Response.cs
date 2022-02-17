using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Files;
using System;
using System.IO;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationAttachments.Download
{
    /// <summary>
    /// Download form registrations attachment file response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public sealed partial class DownloadFormRegistrationAttachmentV1Response : BaseResponse,
        IDownloadFileV1Response,
        IDisposable
    {
        private readonly IDownloadFileV1Response _response;

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadFormRegistrationAttachmentV1Response"/> class.
        /// </summary>
        public DownloadFormRegistrationAttachmentV1Response()
        {
            _response = DownloadFileV1Response.Create(this);
        }

        /// <summary>
        /// Content type
        /// </summary>
        [ExampleValue("image/jpeg")]
        [IgnoreDataMember]
        public string ContentType
        {
            get => _response.ContentType;
            set => _response.ContentType = value;
        }

        /// <summary>
        /// File
        /// </summary>
        [ExampleMemberProvider(typeof(DownloadFormRegistrationAttachmentV1Response), nameof(File))]
        [IgnoreDataMember]
        public Stream File
        {
            get => _response.File;
            set => _response.File = value;
        }

        /// <summary>
        /// File name
        /// </summary>
        [ExampleValue("023FFB97-44D7-4346-BDDD-13D615C52EB6.jpg")]
        [IgnoreDataMember]
        public string FileName
        {
            get => _response.FileName;
            set => _response.FileName = value;
        }

        /// <summary>
        /// Size
        /// </summary>
        [ExampleValue(42L)]
        [IgnoreDataMember]
        public long? Size
        {
            get => _response.Size;
            set => _response.Size = value;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _response.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
