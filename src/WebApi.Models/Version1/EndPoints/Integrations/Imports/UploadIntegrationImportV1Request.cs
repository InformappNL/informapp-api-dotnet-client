using ConnectedDevelopment.InformSystem.WebApi.Models.DataAnnotations;
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

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Imports
{
    /// <summary>
    /// Upload integration import file request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Post)]
    [Path(IntegrationImportV1Constants.UploadRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    [UploadFileRequest(FileParameterName)]
    public partial class UploadIntegrationImportV1Request : BaseRequest,
        IRequest<UploadIntegrationImportV1Response>,
        IUploadFileV1Request,
        IDisposable
    {
        private readonly IUploadFileV1Request _request;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadIntegrationImportV1Request"/> class.
        /// </summary>
        public UploadIntegrationImportV1Request()
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
        public const string FileParamaterDescription = @"File to upload.";

        /// <summary>
        /// Allowed file types
        /// </summary>
        // TODO: Add other allowed file types
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
        /// Integration import Id
        /// </summary>
        [ExampleString(ExampleStringKind.Guid, "7A576DA6-7D32-4037-B936-741F1B236ED5")]
        [IgnoreDataMember]
        [PathParameter]
        [Required]
        public Guid? IntegrationImportId { get; set; }

        /// <summary>
        /// Content type
        /// </summary>
        [BodyParameter]
        [ExampleValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")]
        [IgnoreDataMember]
        string IUploadFileV1Request.ContentType
        {
#pragma warning disable CA1033 // Interface methods should be callable by child types
            get => _request.ContentType;
            set => _request.ContentType = value;
#pragma warning restore CA1033 // Interface methods should be callable by child types
        }

        /// <summary>
        /// File stream
        /// </summary>
        [BodyParameter]
        [ExampleMemberProvider(typeof(UploadIntegrationImportV1Request), nameof(File))]
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
        [BodyParameter]
        [ExampleValue("example.xlsx")]
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
        [BodyParameter]
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
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            _request.Dispose();
        }
    }
}
