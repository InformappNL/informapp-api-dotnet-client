using Informapp.InformSystem.WebApi.Models.DataAnnotations;
using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Http;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Responses;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.Errors;
using Informapp.InformSystem.WebApi.Models.Version1.Files;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.DataSources.UploadDataSource
{
    /// <summary>
    /// Upload data source file request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Put)]
    [Path(DataSourceV1Constants.UploadRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    [UploadFileRequest(FileParameterName)]
    public partial class UploadDataSourceV1Request : BaseRequest,
        IRequest<UploadDataSourceV1Response>,
        IUploadFileV1Request,
        IDisposable
    {
        private readonly IUploadFileV1Request _request;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadDataSourceV1Request"/> class.
        /// </summary>
        public UploadDataSourceV1Request()
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
        public const string FileParamaterDescription =
@"File to upload.
The file must be an xslx file containing one work sheet.
The first row must contain the names of the columns.
The first column must be named Id and contain unique values.
The names of columns may only contain: a-z, A-Z, and 0-9.
The Id values may only contain: a-z, A-Z, 0-9, and the character -";

        /// <summary>
        /// Allowed file types
        /// </summary>
        public const string AllowedFileTypes = "xlsx";

        /// <summary>
        /// Max file name length
        /// </summary>
        public const int MaxFileNameLength = 100;

        /// <summary>
        /// Max file size in bytes
        /// </summary>
        public const long MaxFileSize = 1024L * 1024L * 10L; // 10MB



        /// <summary>
        /// Data source Id
        /// </summary>
        [ExampleString(ExampleStringKind.Guid, "7A576DA6-7D32-4037-B936-741F1B236ED5")]
        [IgnoreDataMember]
        [PathParameter]
        [Required]
        public Guid? DataSourceId { get; set; }

        /// <summary>
        /// Content type
        /// </summary>
        [ExampleValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")]
        [IgnoreDataMember]
        string IUploadFileV1Request.ContentType
        {
            get => _request.ContentType;
            set => _request.ContentType = value;
        }

        /// <summary>
        /// File
        /// </summary>
        [ExampleMemberProvider(typeof(UploadDataSourceV1Request), nameof(File))]
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
        [ExampleValue("projects.xlsx")]
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

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _request.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
