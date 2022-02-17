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

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.AppUsers.CreateAppUser
{
    /// <summary>
    /// Create app user request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Post)]
    [Path(AppUserV1Constants.CreateRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class CreateAppUserV1Request : BaseRequest,
        IRequest<CreateAppUserV1Response>
    {
        /// <summary>
        /// Email
        /// </summary>
        [BodyParameter]
        [DataMember]
        [EmailAddress]
        [ExampleValue(Version1Examples.Email)]
        [MaxLength(AppUserV1Constants.RequestEmailLength)]
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Business group Id
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "012F6FC6-A02D-4CFD-B242-7BD885D47D99")]
        [Required]
        public Guid? BusinessGroupId { get; set; }
    }
}
