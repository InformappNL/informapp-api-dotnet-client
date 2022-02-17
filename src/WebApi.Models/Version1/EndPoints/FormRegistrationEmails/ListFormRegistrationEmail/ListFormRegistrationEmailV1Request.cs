using ConnectedDevelopment.InformSystem.WebApi.Models.DataAnnotations;
using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Http;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Models.Sorting;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Errors;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationEmails.ListFormRegistrationEmail
{
    /// <summary>
    /// List form registration email request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Get)]
    [Path(FormRegistrationEmailV1Constants.ListRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class ListFormRegistrationEmailV1Request : BaseRequest,
        IRequest<ListFormRegistrationEmailV1Response>
    {
        private const int PageSizeMaxValue = 100;

        /// <summary>
        /// Filter records
        /// </summary>
        [DataMember]
        [QueryParameter]
        public ListFormRegistrationEmailV1Filter Filter { get; set; }

        /// <summary>
        /// Select columns
        /// </summary>
        [DataMember]
        [DefaultValue(new[] { ListFormRegistrationEmailV1Select.All })]
        [EnumCollection(typeof(ListFormRegistrationEmailV1Select))]
        [ExampleCollection(ExampleCollectionKind.List, typeof(ListFormRegistrationEmailV1Select), new object[] { ListFormRegistrationEmailV1Select.FormRegistrationId, ListFormRegistrationEmailV1Select.EmailRecipients })]
        [QueryParameter]
        [UniqueItems(typeof(ListFormRegistrationEmailV1Select))]
        public IReadOnlyList<ListFormRegistrationEmailV1Select> Select { get; set; } = new[] { ListFormRegistrationEmailV1Select.All };

        /// <summary>
        /// Sort records
        /// 
        /// Sort by the first column, then by the second column, and so on
        /// </summary>
        [DataMember]
        [DefaultValue(new[] { ListFormRegistrationEmailV1Sort.SerialNumber })]
        [EnumCollection(typeof(ListFormRegistrationEmailV1Sort))]
        [ExampleCollection(ExampleCollectionKind.List, typeof(ListFormRegistrationEmailV1Sort), new object[] { ListFormRegistrationEmailV1Sort.SerialNumber })]
        [MaxItems(Version1PageSortConstants.MaxItems)]
        [QueryParameter]
        [UniqueItems(typeof(ListFormRegistrationEmailV1Sort), typeof(SortEqualityComparer<ListFormRegistrationEmailV1Sort>), ErrorMessage = SortConstants.ErrorMessage)]
        public IReadOnlyList<ListFormRegistrationEmailV1Sort> Sort { get; set; } = new[] { ListFormRegistrationEmailV1Sort.SerialNumber };

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
        [Range(Version1PageSizeConstants.Min, PageSizeMaxValue)]
        public int? PageSize { get; set; } = Version1PageSizeConstants.Default;
    }
}
