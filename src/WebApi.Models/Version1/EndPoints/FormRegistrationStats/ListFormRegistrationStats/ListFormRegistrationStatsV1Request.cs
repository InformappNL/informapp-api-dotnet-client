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

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationStats.ListFormRegistrationStats
{
    /// <summary>
    /// List form registration stats request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Get)]
    [Path(FormRegistrationStatsV1Constants.ListRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class ListFormRegistrationStatsV1Request : BaseRequest,
        IRequest<ListFormRegistrationStatsV1Response>
    {
        private const int PageSizeMaxValue = 100;

        /// <summary>
        /// Filter records
        /// </summary>
        [DataMember]
        [QueryParameter]
        public ListFormRegistrationStatsV1Filter Filter { get; set; }

        /// <summary>
        /// Select columns
        /// </summary>
        [DataMember]
        [DefaultValue(new[] { ListFormRegistrationStatsV1Select.All })]
        [EnumCollection(typeof(ListFormRegistrationStatsV1Select))]
        [ExampleCollection(ExampleCollectionKind.List, typeof(ListFormRegistrationStatsV1Select), new object[] { ListFormRegistrationStatsV1Select.RegistrationCount, ListFormRegistrationStatsV1Select.HighestSerialNumber })]
        [QueryParameter]
        [UniqueItems(typeof(ListFormRegistrationStatsV1Select))]
        public IReadOnlyList<ListFormRegistrationStatsV1Select> Select { get; set; } = new[] { ListFormRegistrationStatsV1Select.All };

        /// <summary>
        /// Sort records
        /// 
        /// Sort by the first column, then by the second column, and so on
        /// </summary>
        [DataMember]
        [DefaultValue(new[] { ListFormRegistrationStatsV1Sort.RegistrationCount })]
        [EnumCollection(typeof(ListFormRegistrationStatsV1Sort))]
        [ExampleCollection(ExampleCollectionKind.List, typeof(ListFormRegistrationStatsV1Sort), new object[] { ListFormRegistrationStatsV1Sort.RegistrationCount })]
        [MaxItems(Version1PageSortConstants.MaxItems)]
        [QueryParameter]
        [UniqueItems(typeof(ListFormRegistrationStatsV1Sort), typeof(SortEqualityComparer<ListFormRegistrationStatsV1Sort>), ErrorMessage = SortConstants.ErrorMessage)]
        public IReadOnlyList<ListFormRegistrationStatsV1Sort> Sort { get; set; } = new[] { ListFormRegistrationStatsV1Sort.RegistrationCount };

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
