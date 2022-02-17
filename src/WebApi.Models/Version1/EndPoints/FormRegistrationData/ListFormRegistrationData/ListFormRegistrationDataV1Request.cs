using ConnectedDevelopment.InformSystem.WebApi.Models.DataAnnotations;
using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Http;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Models.Sorting;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Errors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationData.ListFormRegistrationData
{
    /// <summary>
    /// List form registration data request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Get)]
    [Obsolete("Superseded by " + nameof(ListFormRegistrationDataForRegistrationV1Request))]
    [Path(FormRegistrationDataV1Constants.ListRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class ListFormRegistrationDataV1Request : BaseRequest,
        IRequest<ListFormRegistrationDataV1Response>
    {
        /// <summary>
        /// Filter records
        /// </summary>
        [DataMember]
        [QueryParameter]
        public ListFormRegistrationDataV1Filter Filter { get; set; }

        /// <summary>
        /// Select columns
        /// </summary>
        [DataMember]
        [DefaultValue(new[] { ListFormRegistrationDataV1Select.All })]
        [EnumCollection(typeof(ListFormRegistrationDataV1Select))]
        [ExampleCollection(ExampleCollectionKind.List, typeof(ListFormRegistrationDataV1Select), new object[] { ListFormRegistrationDataV1Select.Name, ListFormRegistrationDataV1Select.ValueText })]
        [QueryParameter]
        [UniqueItems(typeof(ListFormRegistrationDataV1Select))]
        public IReadOnlyList<ListFormRegistrationDataV1Select> Select { get; set; } = new[] { ListFormRegistrationDataV1Select.All };

        /// <summary>
        /// Sort records
        /// 
        /// Sort by the first column, then by the second column, and so on
        /// </summary>
        [DataMember]
        [DefaultValue(new[] { ListFormRegistrationDataV1Sort.SerialNumber })]
        [EnumCollection(typeof(ListFormRegistrationDataV1Sort))]
        [ExampleCollection(ExampleCollectionKind.List, typeof(ListFormRegistrationDataV1Sort), new object[] { ListFormRegistrationDataV1Sort.SerialNumber })]
        [MaxItems(Version1PageSortConstants.MaxItems)]
        [QueryParameter]
        [UniqueItems(typeof(ListFormRegistrationDataV1Sort), typeof(SortEqualityComparer<ListFormRegistrationDataV1Sort>), ErrorMessage = SortConstants.ErrorMessage)]
        public IReadOnlyList<ListFormRegistrationDataV1Sort> Sort { get; set; } = new[] { ListFormRegistrationDataV1Sort.SerialNumber };

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
        [Range(Version1PageSizeConstants.Min, FormRegistrationDataV1Constants.PageSizeMaxValue)]
        public int? PageSize { get; set; } = Version1PageSizeConstants.Default;
    }
}
