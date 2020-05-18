using Informapp.InformSystem.WebApi.Models.DataAnnotations;
using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Http;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Responses;
using Informapp.InformSystem.WebApi.Models.Sorting;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.Errors;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.BusinessGroupCredits.ListBusinessGroupCredit
{
    /// <summary>
    /// List business group credit request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Get)]
    [Path(BusinessGroupCreditV1Constants.ListRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class ListBusinessGroupCreditV1Request : BaseRequest,
        IRequest<ListBusinessGroupCreditV1Response>
    {
        /// <summary>
        /// Filter records
        /// </summary>
        [DataMember]
        [QueryParameter]
        public ListBusinessGroupCreditV1Filter Filter { get; set; }

        /// <summary>
        /// Select columns
        /// </summary>
        [DataMember]
        [DefaultValue(new[] { ListBusinessGroupCreditV1Select.All })]
        [EnumCollection(typeof(ListBusinessGroupCreditV1Select))]
        [ExampleCollection(ExampleCollectionKind.List, typeof(ListBusinessGroupCreditV1Select), new object[] { ListBusinessGroupCreditV1Select.TotalRegistrationCount, ListBusinessGroupCreditV1Select.LastUpdateDate })]
        [QueryParameter]
        [UniqueItems(typeof(ListBusinessGroupCreditV1Select))]
        public IReadOnlyList<ListBusinessGroupCreditV1Select> Select { get; set; } = new[] { ListBusinessGroupCreditV1Select.All };

        /// <summary>
        /// Sort records
        /// 
        /// Sort by the first column, then by the second column, and so on
        /// </summary>
        [DataMember]
        [DefaultValue(new[] { ListBusinessGroupCreditV1Sort.CreateDate })]
        [EnumCollection(typeof(ListBusinessGroupCreditV1Sort))]
        [ExampleCollection(ExampleCollectionKind.List, typeof(ListBusinessGroupCreditV1Sort), new object[] { ListBusinessGroupCreditV1Sort.CreateDate })]
        [MaxItems(Version1PageSortConstants.MaxItems)]
        [QueryParameter]
        [UniqueItems(typeof(ListBusinessGroupCreditV1Sort), typeof(SortEqualityComparer<ListBusinessGroupCreditV1Sort>), ErrorMessage = SortConstants.ErrorMessage)]
        public IReadOnlyList<ListBusinessGroupCreditV1Sort> Sort { get; set; } = new[] { ListBusinessGroupCreditV1Sort.CreateDate };

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
        [Range(Version1PageSizeConstants.Min, BusinessGroupCreditV1Constants.PageSizeMaxValue)]
        public int? PageSize { get; set; } = Version1PageSizeConstants.Default;
    }
}
