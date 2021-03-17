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

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormDataNames
{
    /// <summary>
    /// List form data name request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Get)]
    [Path(FormDataNameV1Constants.ListRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class ListFormDataNameV1Request : BaseRequest,
        IRequest<ListFormDataNameV1Response>
    {
        /// <summary>
        /// Form id
        /// </summary>
        [ExampleString(ExampleStringKind.Guid, "18EDECB1-D08E-44DF-8657-E1437D6EDFB7")]
        [IgnoreDataMember]
        [PathParameter]
        //[Required]
        public Guid? FormId { get; set; }

        /// <summary>
        /// Select columns
        /// </summary>
        [DataMember]
        [DefaultValue(new[] { ListFormDataNameV1Select.All })]
        [EnumCollection(typeof(ListFormDataNameV1Select))]
        [ExampleCollection(ExampleCollectionKind.List, typeof(ListFormDataNameV1Select), new object[] { ListFormDataNameV1Select.Name, ListFormDataNameV1Select.FullName })]
        [QueryParameter]
        [UniqueItems(typeof(ListFormDataNameV1Select))]
        public IReadOnlyList<ListFormDataNameV1Select> Select { get; set; } = new[] { ListFormDataNameV1Select.All };

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
        [Range(Version1PageSizeConstants.Min, FormDataNameV1Constants.PageSizeMaxValue)]
        public int? PageSize { get; set; } = Version1PageSizeConstants.Default;
    }
}
