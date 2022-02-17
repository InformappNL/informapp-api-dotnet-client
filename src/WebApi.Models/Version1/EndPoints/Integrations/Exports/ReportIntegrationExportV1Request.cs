using ConnectedDevelopment.InformSystem.WebApi.Models.DataAnnotations;
using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Http;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Errors;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Exports
{
    /// <summary>
    /// Report integration export request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Post)]
    [Path(IntegrationExportV1Constants.ReportRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class ReportIntegrationExportV1Request : BaseRequest,
        IRequest<ReportIntegrationExportV1Response>
    {
        /// <summary>
        /// Integration export id
        /// </summary>
        [ExampleString(ExampleStringKind.Guid, "CF760736-C07F-4BA6-B30A-72C1ED37D381")]
        [IgnoreDataMember]
        [PathParameter]
        [Required]
        public Guid? IntegrationExportId { get; set; }

        /// <summary>
        /// Integration export log id
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "3FFE3E89-FE8D-4EEE-9ACC-83FCA04B7B52")]
        [Required]
        public Guid? IntegrationExportLogId { get; set; }

        /// <summary>
        /// Result
        /// </summary>
        [BodyParameter]
        [DataMember]
        [EnumValidation(typeof(DownloadIntegrationExportV1Result))]
        [ExampleValue(DownloadIntegrationExportV1Result.Success)]
        [Required]
        public DownloadIntegrationExportV1Result? Result { get; set; }

        /// <summary>
        /// Duration in milliseconds
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue(60)]
        [Range(IntegrationExportV1Constants.MinDurationNumber, IntegrationExportV1Constants.MaxDurationNumber)]
        [Required]
        public int? Duration { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue("Message")]
        [MaxLength(IntegrationExportV1Constants.MessageLength)]
        public string Message { get; set; }

        /// <summary>
        /// Exception
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue("Exception")]
        [MaxLength(IntegrationExportV1Constants.ExceptionLength)]
        public string Exception { get; set; }
    }
}
