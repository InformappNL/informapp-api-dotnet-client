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

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.BusinessGroups.ListBusinessGroup
{
    /// <summary>
    /// List business group request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Get)]
    [Path(BusinessGroupV1Constants.ListRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class ListBusinessGroupV1Request : BaseRequest,
        IRequest<ListBusinessGroupV1Response>
    {
        /// <summary>
        /// Filter records
        /// </summary>
        [DataMember]
        [QueryParameter]
        public ListBusinessGroupV1Filter Filter { get; set; }

        /// <summary>
        /// Select columns
        /// </summary>
        [DataMember]
        [DefaultValue(new[] { ListBusinessGroupV1Select.All })]
        [EnumCollection(typeof(ListBusinessGroupV1Select))]
        [ExampleCollection(ExampleCollectionKind.List, typeof(ListBusinessGroupV1Select), new object[] { ListBusinessGroupV1Select.Name, ListBusinessGroupV1Select.Description })]
        [QueryParameter]
        [UniqueItems(typeof(ListBusinessGroupV1Select))]
        public IEnumerable<ListBusinessGroupV1Select> Select { get; set; } = new[] { ListBusinessGroupV1Select.All };

        /// <summary>
        /// Sort records
        /// 
        /// Sort by the first column, then by the second column, and so on
        /// </summary>
        [DataMember]
        [DefaultValue(new[] { ListBusinessGroupV1Sort.Name })]
        [EnumCollection(typeof(ListBusinessGroupV1Sort))]
        [ExampleCollection(ExampleCollectionKind.List, typeof(ListBusinessGroupV1Sort), new object[] { ListBusinessGroupV1Sort.Name })]
        [MaxItems(Version1PageSortConstants.MaxItems)]
        [QueryParameter]
        [UniqueItems(typeof(ListBusinessGroupV1Sort), typeof(SortEqualityComparer<ListBusinessGroupV1Sort>), ErrorMessage = SortConstants.ErrorMessage)]
        public IEnumerable<ListBusinessGroupV1Sort> Sort { get; set; } = new[] { ListBusinessGroupV1Sort.Name };

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
        [Range(Version1PageSizeConstants.Min, BusinessGroupV1Constants.PageSizeMaxValue)]
        public int? PageSize { get; set; } = Version1PageSizeConstants.Default;
    }
}
