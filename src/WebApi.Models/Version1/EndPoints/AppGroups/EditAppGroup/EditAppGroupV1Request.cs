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

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.AppGroups.EditAppGroup
{
    /// <summary>
    /// Edit app group request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Put)]
    [Path(AppGroupV1Constants.EditRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class EditAppGroupV1Request : BaseRequest,
        IRequest<EditAppGroupV1Response>
    {
        /// <summary>
        /// App group id
        /// </summary>
        [ExampleString(ExampleStringKind.Guid, "5A1C1498-26F8-4C48-9928-FAB1BDB545D1")]
        [IgnoreDataMember]
        [PathParameter]
        [Required]
        public Guid? AppGroupId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue("Inspectors")]
        [MaxLength(AppGroupV1Constants.RequestNameLength)]
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue("Inspectors")]
        [MaxLength(AppGroupV1Constants.RequestDescriptionLength)]
        public string Description { get; set; }
    }
}
