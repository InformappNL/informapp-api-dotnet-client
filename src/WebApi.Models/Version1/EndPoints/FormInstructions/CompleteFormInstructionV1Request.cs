using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Http;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Errors;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormInstructions
{
    /// <summary>
    /// Complete form instruction request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Put)]
    [Path(FormInstructionV1Constants.CompleteRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class CompleteFormInstructionV1Request : BaseRequest,
        IRequest<CompleteFormInstructionV1Response>
    {
        /// <summary>
        /// Form instruction id
        /// </summary>
        [ExampleString(ExampleStringKind.Guid, "4E0B06C7-C8BC-4816-AAB3-F1716A4B2413")]
        [IgnoreDataMember]
        [PathParameter]
        [Required]
        public Guid? FormInstructionId { get; set; }
    }
}
