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

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppGroups.CreateAppGroup
{
    /// <summary>
    /// Create app group request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Post)]
    [Path(AppGroupV1Constants.CreateRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class CreateAppGroupV1Request : BaseRequest,
        IRequest<CreateAppGroupV1Response>
    {
        /// <summary>
        /// Name
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue("Inspectors")]
        [MaxLength(AppGroupV1Constants.RequestNameLength)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue("Inspectors")]
        [MaxLength(AppGroupV1Constants.RequestDescriptionLength)]
        public string Description { get; set; }

        /// <summary>
        /// Business group Id
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "E299A198-E5C6-417C-9CAC-B94D621861D4")]
        [Required]
        public Guid? BusinessGroupId { get; set; }
    }
}
