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

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppGroups.DeleteAppGroup
{
    /// <summary>
    /// Delete app group request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Delete)]
    [Path(AppGroupV1Constants.DeleteRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class DeleteAppGroupV1Request : BaseRequest,
        IRequest<DeleteAppGroupV1Response>
    {
        /// <summary>
        /// AppGroup Id
        /// </summary>
        [ExampleString(ExampleStringKind.Guid, "60F7C892-C2A2-4334-A1AA-D1A2E8823046")]
        [IgnoreDataMember]
        [PathParameter]
        [Required]
        public Guid? AppGroupId { get; set; }
    }
}
