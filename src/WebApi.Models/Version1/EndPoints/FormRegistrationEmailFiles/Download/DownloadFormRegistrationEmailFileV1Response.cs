using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Files;
using System;
using System.IO;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationEmailFiles.Download
{
    /// <summary>
    /// Download form registrations email file response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public sealed partial class DownloadFormRegistrationEmailFileV1Response : BaseResponse,
        IDownloadFileV1Response,
        IDisposable
    {
        private readonly IDownloadFileV1Response _response;

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadFormRegistrationEmailFileV1Response"/> class.
        /// </summary>
        public DownloadFormRegistrationEmailFileV1Response()
        {
            _response = DownloadFileV1Response.Create(this);
        }

        /// <summary>
        /// Content type
        /// </summary>
        [ExampleValue("application/pdf")]
        [IgnoreDataMember]
        public string ContentType
        {
            get => _response.ContentType;
            set => _response.ContentType = value;
        }

        /// <summary>
        /// File
        /// </summary>
        [ExampleMemberProvider(typeof(DownloadFormRegistrationEmailFileV1Response), nameof(File))]
        [IgnoreDataMember]
        public Stream File
        {
            get => _response.File;
            set => _response.File = value;
        }

        /// <summary>
        /// File name
        /// </summary>
        [ExampleValue("543EE644-9677-4CBB-8272-FF9E5D9D8A9E.pdf")]
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
