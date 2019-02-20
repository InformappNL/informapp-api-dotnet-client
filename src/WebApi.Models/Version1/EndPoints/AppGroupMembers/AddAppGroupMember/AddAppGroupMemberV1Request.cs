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

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppGroupMembers.AddAppGroupMember
{
    /// <summary>
    /// Add app group member request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Put)]
    [Path(AppGroupMemberV1Constants.AddRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class AddAppGroupMemberV1Request : BaseRequest,
        IRequest<AddAppGroupMemberV1Response>
    {
        /// <summary>
        /// Members to add
        /// </summary>
        [BodyParameter]
        [DataMember]
        [MaxItems(AppGroupMemberV1Constants.AddMaxItems)]
        [MinItems(AppGroupMemberV1Constants.AddMinItems)]
        [Required]
        [UniqueItems(typeof(AddAppGroupMemberV1RequestAppGroupMember), typeof(AddAppGroupMemberV1RequestAppGroupMemberEqualityComparer))]
        public IEnumerable<AddAppGroupMemberV1RequestAppGroupMember> Members { get; set; }
    }
}
