using Informapp.InformSystem.WebApi.Models.DataAnnotations;
using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Http;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Responses;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.Errors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationData
{
    /// <summary>
    /// List form registration data for registration request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Get)]
    [Path(FormRegistrationDataV1Constants.ListRouteForRegistration)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class ListFormRegistrationDataForRegistrationV1Request : BaseRequest,
        IRequest<ListFormRegistrationDataForRegistrationV1Response>
    {
        /// <summary>
        /// Form registration id
        /// </summary>
        [ExampleString(ExampleStringKind.Guid, "F879E62A-F96A-4276-B2B3-573E99BA222A")]
        [IgnoreDataMember]
        [PathParameter]
        //[Required]
        public Guid? FormRegistrationId { get; set; }

        /// <summary>
        /// Select columns
        /// </summary>
        [DataMember]
        [DefaultValue(new[] { ListFormRegistrationDataForRegistrationV1Select.All })]
        [EnumCollection(typeof(ListFormRegistrationDataForRegistrationV1Select))]
        [ExampleCollection(ExampleCollectionKind.List, typeof(ListFormRegistrationDataForRegistrationV1Select), new object[] { ListFormRegistrationDataForRegistrationV1Select.Name, ListFormRegistrationDataForRegistrationV1Select.ValueText })]
        [QueryParameter]
        [UniqueItems(typeof(ListFormRegistrationDataForRegistrationV1Select))]
        public IReadOnlyList<ListFormRegistrationDataForRegistrationV1Select> Select { get; set; } = new[] { ListFormRegistrationDataForRegistrationV1Select.All };

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
