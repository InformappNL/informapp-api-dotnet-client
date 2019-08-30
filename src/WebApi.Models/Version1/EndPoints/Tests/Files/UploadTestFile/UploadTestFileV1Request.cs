﻿using Informapp.InformSystem.WebApi.Models.DataAnnotations;
using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Http;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Responses;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.Errors;
using Informapp.InformSystem.WebApi.Models.Version1.Files;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Files.UploadTestFile
{
    /// <summary>
    /// Upload test file request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Post)]
    [Path(TestFileV1Constants.GetRoute)]
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
        public const string AllowedFileTypes = ".docx .pdf .txt .xlsx";

        /// <summary>
        /// Max file name length
        /// </summary>
        public const int MaxFileNameLength = 100;

        /// <summary>
        /// Max file size in bytes
        /// </summary>
        public const long MaxFileSize = 1024 * 40; // 40 KB




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
            get { return _request.FileName; }
            set { _request.FileName = value; }
        }

        /// <summary>
        /// File
        /// </summary>
        [ExampleMemberProvider(typeof(UploadTestFileV1Request), nameof(File))]
        [FileSize(MaxFileSize)]
        [IgnoreDataMember]
        [Required]
        public Stream File
        {
            get { return _request.File; }
            set { _request.File = value; }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _request.Dispose();
        }
    }
}