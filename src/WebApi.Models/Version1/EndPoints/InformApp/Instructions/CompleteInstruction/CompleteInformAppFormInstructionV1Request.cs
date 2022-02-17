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

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Instructions.CompleteInstruction
{
    /// <summary>
    /// Complete form instruction request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Post)]
    [Path(InformAppInstructionV1Constants.CompleteRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class CompleteInformAppFormInstructionV1Request : BaseRequest,
        IRequest<CompleteInformAppFormInstructionV1Response>
    {
        /// <summary>
        /// Form id
        /// </summary>
        [ExampleString(ExampleStringKind.Guid, "4E0B06C7-C8BC-4816-AAB3-F1716A4B2413")]
        [IgnoreDataMember]
        [PathParameter]
        [Required]
        public Guid? FormId { get; set; }

        /// <summary>
        /// Instruction id
        /// </summary>
        [ExampleValue("5cbf0039a6feee2523549291")]
        [IgnoreDataMember]
        [MaxLength(InformAppInstructionV1Constants.RequestInstructionIdLength)]
        [PathParameter]
        [Required]
        public string InstructionId { get; set; }
    }
}
