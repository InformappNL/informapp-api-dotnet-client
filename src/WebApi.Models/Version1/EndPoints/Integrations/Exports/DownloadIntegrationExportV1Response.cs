using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.Files;
using System;
using System.IO;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Exports
{
    /// <summary>
    /// Download integration export response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public partial class DownloadIntegrationExportV1Response : BaseResponse,
        IDownloadFileV1Response,
        IDisposable
    {
        private readonly IDownloadFileV1Response _response;

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadIntegrationExportV1Response"/> class.
        /// </summary>
        public DownloadIntegrationExportV1Response()
        {
            _response = DownloadFileV1Response.Create(this);
        }

        /// <summary>
        /// Content type
        /// </summary>
        [ExampleValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")]
        [IgnoreDataMember]
        public string ContentType
        {
            get => _response.ContentType;
            set => _response.ContentType = value;
        }

        /// <summary>
        /// File
        /// </summary>
        [ExampleMemberProvider(typeof(DownloadIntegrationExportV1Response), nameof(File))]
        [IgnoreDataMember]
        public Stream File
        {
            get => _response.File;
            set => _response.File = value;
        }

        /// <summary>
        /// File name
        /// </summary>
        [ExampleValue("projects.xlsx")]
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
