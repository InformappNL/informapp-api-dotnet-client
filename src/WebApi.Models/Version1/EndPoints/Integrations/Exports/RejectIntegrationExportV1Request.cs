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
    /// Reject integration export request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Post)]
    [Path(IntegrationExportV1Constants.RejectRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class RejectIntegrationExportV1Request : BaseRequest,
        IRequest<RejectIntegrationExportV1Response>
    {
        /// <summary>
        /// Integration export id
        /// </summary>
        [ExampleString(ExampleStringKind.Guid, "D8528F4D-89B3-4C78-B16C-B59C000C8C6E")]
        [IgnoreDataMember]
        [PathParameter]
        [Required]
        public Guid? IntegrationExportId { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue("Message")]
        [MaxLength(IntegrationExportV1Constants.MessageLength)]
        public string Message { get; set; }
    }
}
