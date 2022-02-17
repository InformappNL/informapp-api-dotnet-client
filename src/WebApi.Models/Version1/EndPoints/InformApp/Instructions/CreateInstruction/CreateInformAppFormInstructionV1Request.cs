using ConnectedDevelopment.InformSystem.WebApi.Models.DataAnnotations;
using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Http;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Errors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Instructions.CreateInstruction
{
    /// <summary>
    /// Create form instruction request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Post)]
    [Path(InformAppInstructionV1Constants.CreateRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public partial class CreateInformAppFormInstructionV1Request : BaseRequest,
        IRequest<CreateInformAppFormInstructionV1Response>
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
        [MaxLength(InformAppInstructionV1Constants.RequestMessgeLength)]
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
        [ExampleMemberProvider(typeof(CreateInformAppFormInstructionV1Request), nameof(FormData))]
        public IReadOnlyDictionary<string, object> FormData { get; set; }

        /// <summary>
        /// Publish date
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        [Required]
        public DateTimeOffset? PublishDate { get; set; }

        /// <summary>
        /// Recipients
        /// Value can be an email adres or a user id
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleMemberProvider(typeof(CreateInformAppFormInstructionV1Request), nameof(Recipients))]
        [MinItems(1)]
        [Required]
        public IReadOnlyList<string> Recipients { get; set; }
    }
}
