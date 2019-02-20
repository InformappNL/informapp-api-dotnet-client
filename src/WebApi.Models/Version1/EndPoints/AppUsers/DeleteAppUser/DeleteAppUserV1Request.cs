using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Http;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Responses;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.Errors;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppUsers.DeleteAppUser
{
    /// <summary>
    /// Delete app user request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Delete)]
    [Path(AppUserV1Constants.DeleteRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class DeleteAppUserV1Request : BaseRequest,
        IRequest<DeleteAppUserV1Response>
    {
        /// <summary>
        /// App user Id
        /// </summary>
        [ExampleString(ExampleStringKind.Guid, "A0CCED9B-D167-4728-8101-C6FA330888A0")]
        [IgnoreDataMember]
        [PathParameter]
        [Required]
        public Guid? AppUserId { get; set; }
    }
}
