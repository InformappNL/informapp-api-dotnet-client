﻿using ConnectedDevelopment.InformSystem.WebApi.Models.DataAnnotations;
using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Http;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Errors;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Files;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Files.UploadTestFile
{
    /// <summary>
    /// Upload test file request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Post)]
    [Path(TestFileV1Constants.UploadRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    [UploadFileRequest(FileParameterName)]
    public partial class UploadTestFileV1Request : BaseRequest,
        IRequest<UploadTestFileV1Response>,
        IUploadFileV1Request,
        IDisposable
    {
        private readonly IUploadFileV1Request _request;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadTestFileV1Request"/> class.
        /// </summary>
        public UploadTestFileV1Request()
        {
            _request = UploadFileV1Request.Create(this);
        }

        /// <summary>
        /// File parameter name
        /// </summary>
        public const string FileParameterName = nameof(File);

        /// <summary>
        /// File parameter description
        /// </summary>
        public const string FileParamaterDescription = "File to upload.";

        /// <summary>
        /// Allowed file types
        /// </summary>
        public const string AllowedFileTypes = "docx pdf txt xlsx";

        /// <summary>
        /// Max file name length
        /// </summary>
        public const int MaxFileNameLength = 100;

        /// <summary>
        /// Max file size in bytes
        /// </summary>
        public const long MaxFileSize = 1024 * 40; // 40 KB



        /// <summary>
        /// Content type
        /// Explicitly implemented as this field is not required but used internally
        /// </summary>
        [ExampleValue("text/plain")]
        [IgnoreDataMember]
        string IUploadFileV1Request.ContentType
        {
#pragma warning disable CA1033 // Interface methods should be callable by child types
            get => _request.ContentType;
            set => _request.ContentType = value;
#pragma warning restore CA1033 // Interface methods should be callable by child types
        }

        /// <summary>
        /// File
        /// </summary>
        [ExampleMemberProvider(typeof(UploadTestFileV1Request), nameof(File))]
        [IgnoreDataMember]
        [Required]
        public Stream File
        {
            get => _request.File;
            set => _request.File = value;
        }

        /// <summary>
        /// File name
        /// </summary>
        [ExampleValue("example.txt")]
        [FileNameLength(MaxFileNameLength)]
        [FileType(AllowedFileTypes)]
        [IgnoreDataMember]
        [Required]
        public string FileName
        {
            get => _request.FileName;
            set => _request.FileName = value;
        }

        /// <summary>
        /// Size
        /// </summary>
        [ExampleValue(42L)]
        [FileSize(MaxFileSize)]
        [IgnoreDataMember]
        [Required]
        public long? Size
        {
            get => _request.Size;
            set => _request.Size = value;
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
                    _request.Dispose();
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
