using Informapp.InformSystem.WebApi.Models.DataAnnotations;
using Informapp.InformSystem.WebApi.Models.Http;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Responses;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.Errors;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppGroupMembers.RemoveAppGroupMember
{
    /// <summary>
    /// Remove app group member request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Delete)]
    [Path(AppGroupMemberV1Constants.RemoveRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class RemoveAppGroupMemberV1Request : BaseRequest,
        IRequest<RemoveAppGroupMemberV1Response>
    {
        /// <summary>
        /// Members to add
        /// </summary>
        [BodyParameter]
        [DataMember]
        [MaxItems(AppGroupMemberV1Constants.RemoveMaxItems)]
        [MinItems(AppGroupMemberV1Constants.RemoveMinItems)]
        [Required]
        [UniqueItems(typeof(RemoveAppGroupMemberV1RequestAppGroupMember), typeof(RemoveAppGroupMemberV1RequestAppGroupMemberEqualityComparer))]
        public IReadOnlyList<RemoveAppGroupMemberV1RequestAppGroupMember> Members { get; set; }
    }
}
