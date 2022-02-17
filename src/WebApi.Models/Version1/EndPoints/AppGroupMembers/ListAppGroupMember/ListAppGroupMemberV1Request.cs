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

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.AppGroupMembers.ListAppGroupMember
{
    /// <summary>
    /// List app group member request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Get)]
    [Path(AppGroupMemberV1Constants.ListRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class ListAppGroupMemberV1Request : BaseRequest,
        IRequest<ListAppGroupMemberV1Response>
    {
        /// <summary>
        /// Filter records
        /// </summary>
        [DataMember]
        [QueryParameter]
        public ListAppGroupMemberV1Filter Filter { get; set; }

        /// <summary>
        /// Select columns
        /// </summary>
        [DataMember]
        [DefaultValue(new[] { ListAppGroupMemberV1Select.All })]
        [EnumCollection(typeof(ListAppGroupMemberV1Select))]
        [ExampleCollection(ExampleCollectionKind.List, typeof(ListAppGroupMemberV1Select), new object[] { ListAppGroupMemberV1Select.CreateDate })]
        [QueryParameter]
        [UniqueItems(typeof(ListAppGroupMemberV1Select))]
        public IReadOnlyList<ListAppGroupMemberV1Select> Select { get; set; } = new[] { ListAppGroupMemberV1Select.All };

        /// <summary>
        /// Sort records
        /// 
        /// Sort by the first column, then by the second column, and so on
        /// </summary>
        [DataMember]
        [DefaultValue(new[] { ListAppGroupMemberV1Sort.CreateDate })]
        [EnumCollection(typeof(ListAppGroupMemberV1Sort))]
        [ExampleCollection(ExampleCollectionKind.List, typeof(ListAppGroupMemberV1Sort), new object[] { ListAppGroupMemberV1Sort.CreateDate })]
        [MaxItems(Version1PageSortConstants.MaxItems)]
        [QueryParameter]
        [UniqueItems(typeof(ListAppGroupMemberV1Sort), typeof(SortEqualityComparer<ListAppGroupMemberV1Sort>), ErrorMessage = SortConstants.ErrorMessage)]
        public IReadOnlyList<ListAppGroupMemberV1Sort> Sort { get; set; } = new[] { ListAppGroupMemberV1Sort.CreateDate };

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
        [Range(Version1PageSizeConstants.Min, AppGroupMemberV1Constants.PageSizeMaxValue)]
        public int? PageSize { get; set; } = Version1PageSizeConstants.Default;
    }
}
