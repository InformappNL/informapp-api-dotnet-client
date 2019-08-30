using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.Files;
using System;
using System.IO;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Files.DownloadTestFile
{
    /// <summary>
    /// Download test file response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public partial class DownloadTestFileV1Response : BaseResponse,
        IDownloadFileV1Response,
        IDisposable
    {
        private readonly IDownloadFileV1Response _response;

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadTestFileV1Response"/> class.
        /// </summary>
        public DownloadTestFileV1Response()
        {
            _response = DownloadFileV1Response.Create(this);
        }

        /// <summary>
        /// File name
        /// </summary>
        [ExampleValue("example.txt")]
        [IgnoreDataMember]
        public string FileName
        {
            get { return _response.FileName; }
            set { _response.FileName = value; }
        }

        /// <summary>
        /// File
        /// </summary>
        [ExampleMemberProvider(typeof(DownloadTestFileV1Response), nameof(File))]
        [IgnoreDataMember]
        public Stream File
        {
            get { return _response.File; }
            set { _response.File = value; }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _response.Dispose();
        }
    }
}
