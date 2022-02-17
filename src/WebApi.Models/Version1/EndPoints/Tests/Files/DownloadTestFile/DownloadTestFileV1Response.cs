using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Files;
using System;
using System.IO;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Files.DownloadTestFile
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
        /// Content type
        /// </summary>
        [ExampleValue("text/plain")]
        [IgnoreDataMember]
        public string ContentType
        {
            get => _response.ContentType;
            set => _response.ContentType = value;
        }

        /// <summary>
        /// File
        /// </summary>
        [ExampleMemberProvider(typeof(DownloadTestFileV1Response), nameof(File))]
        [IgnoreDataMember]
        public Stream File
        {
            get => _response.File;
            set => _response.File = value;
        }

        /// <summary>
        /// File name
        /// </summary>
        [ExampleValue("example.txt")]
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

        #region IDisposable

        private bool _isDisposed;

        /// <summary>
        /// Releases the unmanaged resources used and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed == false)
            {
                if (disposing)
                {
                    _response.Dispose();
                }

                _isDisposed = true;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);

            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
