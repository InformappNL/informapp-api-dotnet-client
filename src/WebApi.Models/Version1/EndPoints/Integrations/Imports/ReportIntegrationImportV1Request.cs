using Informapp.InformSystem.WebApi.Models.DataAnnotations;
using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Http;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Responses;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.Errors;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Imports
{
    /// <summary>
    /// Report integration import request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Post)]
    [Path(IntegrationImportV1Constants.ReportRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class ReportIntegrationImportV1Request : BaseRequest,
        IRequest<ReportIntegrationImportV1Response>
    {
        /// <summary>
        /// Integration import id
        /// </summary>
        [ExampleString(ExampleStringKind.Guid, "CF760736-C07F-4BA6-B30A-72C1ED37D381")]
        [IgnoreDataMember]
        [PathParameter]
        [Required]
        public Guid? IntegrationImportId { get; set; }

        /// <summary>
        /// Result
        /// </summary>
        [BodyParameter]
        [DataMember]
        [EnumValidation(typeof(UploadIntegrationImportV1Result))]
        [ExampleValue(UploadIntegrationImportV1Result.Success)]
        [Required]
        public UploadIntegrationImportV1Result? Result { get; set; }

        /// <summary>
        /// Duration in milliseconds
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue(60)]
        [Range(IntegrationImportV1Constants.MinDurationNumber, IntegrationImportV1Constants.MaxDurationNumber)]
        [Required]
        public int? Duration { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue("Message")]
        [MaxLength(IntegrationImportV1Constants.MessageLength)]
        public string Message { get; set; }

        /// <summary>
        /// Exception
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue("Exception")]
        [MaxLength(IntegrationImportV1Constants.ExceptionLength)]
        public string Exception { get; set; }
    }
}
