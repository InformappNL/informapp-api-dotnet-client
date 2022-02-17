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

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrations.ListFormRegistration
{
    /// <summary>
    /// List form registration request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Get)]
    [Path(FormRegistrationV1Constants.ListRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class ListFormRegistrationV1Request : BaseRequest,
        IRequest<ListFormRegistrationV1Response>
    {
        /// <summary>
        /// Filter records
        /// </summary>
        [DataMember]
        [QueryParameter]
        public ListFormRegistrationV1Filter Filter { get; set; }

        /// <summary>
        /// Select columns
        /// </summary>
        [DataMember]
        [DefaultValue(new[] { ListFormRegistrationV1Select.All })]
        [EnumCollection(typeof(ListFormRegistrationV1Select))]
        [ExampleCollection(ExampleCollectionKind.List, typeof(ListFormRegistrationV1Select), new object[] { ListFormRegistrationV1Select.SerialNumber, ListFormRegistrationV1Select.FormId })]
        [QueryParameter]
        [UniqueItems(typeof(ListFormRegistrationV1Select))]
        public IReadOnlyList<ListFormRegistrationV1Select> Select { get; set; } = new[] { ListFormRegistrationV1Select.All };

        /// <summary>
        /// Sort records
        /// 
        /// Sort by the first column, then by the second column, and so on
        /// </summary>
        [DataMember]
        [DefaultValue(new[] { ListFormRegistrationV1Sort.SerialNumber })]
        [EnumCollection(typeof(ListFormRegistrationV1Sort))]
        [ExampleCollection(ExampleCollectionKind.List, typeof(ListFormRegistrationV1Sort), new object[] { ListFormRegistrationV1Sort.SerialNumber })]
        [MaxItems(Version1PageSortConstants.MaxItems)]
        [QueryParameter]
        [UniqueItems(typeof(ListFormRegistrationV1Sort), typeof(SortEqualityComparer<ListFormRegistrationV1Sort>), ErrorMessage = SortConstants.ErrorMessage)]
        public IReadOnlyList<ListFormRegistrationV1Sort> Sort { get; set; } = new[] { ListFormRegistrationV1Sort.SerialNumber };

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
        [Range(Version1PageSizeConstants.Min, FormRegistrationV1Constants.PageSizeMaxValue)]
        public int? PageSize { get; set; } = Version1PageSizeConstants.Default;
    }
}
