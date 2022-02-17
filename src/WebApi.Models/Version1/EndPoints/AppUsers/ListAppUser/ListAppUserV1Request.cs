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

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.AppUsers.ListAppUser
{
    /// <summary>
    /// List app user request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Get)]
    [Path(AppUserV1Constants.ListRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class ListAppUserV1Request : BaseRequest,
        IRequest<ListAppUserV1Response>
    {
        /// <summary>
        /// Filter records
        /// </summary>
        [DataMember]
        [QueryParameter]
        public ListAppUserV1Filter Filter { get; set; }

        /// <summary>
        /// Select columns
        /// </summary>
        [DataMember]
        [DefaultValue(new[] { ListAppUserV1Select.All })]
        [EnumCollection(typeof(ListAppUserV1Select))]
        [ExampleCollection(ExampleCollectionKind.List, typeof(ListAppUserV1Select), new object[] { ListAppUserV1Select.Email, ListAppUserV1Select.BusinessGroupId })]
        [QueryParameter]
        [UniqueItems(typeof(ListAppUserV1Select))]
        public IReadOnlyList<ListAppUserV1Select> Select { get; set; } = new[] { ListAppUserV1Select.All };

        /// <summary>
        /// Sort records
        /// 
        /// Sort by the first column, then by the second column, and so on
        /// </summary>
        [DataMember]
        [DefaultValue(new[] { ListAppUserV1Sort.Email })]
        [EnumCollection(typeof(ListAppUserV1Sort))]
        [ExampleCollection(ExampleCollectionKind.List, typeof(ListAppUserV1Sort), new object[] { ListAppUserV1Sort.Email })]
        [MaxItems(Version1PageSortConstants.MaxItems)]
        [QueryParameter]
        [UniqueItems(typeof(ListAppUserV1Sort), typeof(SortEqualityComparer<ListAppUserV1Sort>), ErrorMessage = SortConstants.ErrorMessage)]
        public IReadOnlyList<ListAppUserV1Sort> Sort { get; set; } = new[] { ListAppUserV1Sort.Email };

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
        [Range(Version1PageSizeConstants.Min, AppUserV1Constants.PageSizeMaxValue)]
        public int? PageSize { get; set; } = Version1PageSizeConstants.Default;
    }
}
