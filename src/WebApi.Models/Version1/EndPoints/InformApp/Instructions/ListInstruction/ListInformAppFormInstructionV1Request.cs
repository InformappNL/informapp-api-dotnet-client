using ConnectedDevelopment.InformSystem.WebApi.Models.DataAnnotations;
using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Http;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Errors;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Instructions.ListInstruction
{
    /// <summary>
    /// List form instruction request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Get)]
    [Path(InformAppInstructionV1Constants.ListRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class ListInformAppFormInstructionV1Request : BaseRequest,
        IRequest<ListInformAppFormInstructionV1Response>
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
        /// Filter records
        /// </summary>
        [DataMember]
        [QueryParameter]
        public ListInformAppFormInstructionV1Filter Filter { get; set; }

        /// <summary>
        /// Sort records
        /// </summary>
        [DataMember]
        [DefaultValue(ListInformAppFormInstructionV1Sort.CreateDateDesc)]
        [EnumValidation(typeof(ListInformAppFormInstructionV1Sort))]
        [ExampleValue(ListInformAppFormInstructionV1Sort.CreateDateDesc)]
        [QueryParameter]
        public ListInformAppFormInstructionV1Sort? Sort { get; set; } = ListInformAppFormInstructionV1Sort.CreateDateDesc;

        /// <summary>
        /// Page number
        /// </summary>
        [DataMember]
        [DefaultValue(Version1PageNumberConstants.Default)]
        [ExampleValue(Version1PageNumberConstants.Example)]
        [QueryParameter]
        [Range(Version1PageNumberConstants.Min, Version1PageNumberConstants.Max)]
        public int? PageNumber { get; set; } = Version1PageNumberConstants.Default;

        /// <summary>
        /// Number of records per page
        /// </summary>
        [DataMember]
        [DefaultValue(Version1PageSizeConstants.Default)]
        [ExampleValue(Version1PageSizeConstants.Example)]
        [QueryParameter]
        [Range(Version1PageSizeConstants.Min, InformAppInstructionV1Constants.PageSizeMaxValue)]
        public int? PageSize { get; set; } = Version1PageSizeConstants.Default;
    }
}
