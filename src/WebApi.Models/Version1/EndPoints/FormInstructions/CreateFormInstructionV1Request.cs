using Informapp.InformSystem.WebApi.Models.DataAnnotations;
using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Http;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Responses;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.Errors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormInstructions
{
    /// <summary>
    /// Create form instruction request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Post)]
    [Path(FormInstructionV1Constants.CreateRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public partial class CreateFormInstructionV1Request : BaseRequest,
        IRequest<CreateFormInstructionV1Response>
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
        /// Message
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue("Please complete the order")]
        [MaxLength(FormInstructionV1Constants.RequestMessgeLength)]
        public string Message { get; set; }

        /// <summary>
        /// Information date
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? InformationDate { get; set; }

        /// <summary>
        /// Form data
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleMemberProvider(typeof(CreateFormInstructionV1Request), nameof(FormData))]
        [JsonDeserialize(typeof(Dictionary<string, object>), "Dictionary<string, object>")]
        public string FormData { get; set; }

        /// <summary>
        /// Publish date
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        [Required]
        public DateTimeOffset? PublishDate { get; set; }

        /// <summary>
        /// App user Ids
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleMemberProvider(typeof(CreateFormInstructionV1Request), nameof(AppUserIds))]
        [MinItems(1)]
        [Required]
        public IReadOnlyList<Guid?> AppUserIds { get; set; }
    }
}
