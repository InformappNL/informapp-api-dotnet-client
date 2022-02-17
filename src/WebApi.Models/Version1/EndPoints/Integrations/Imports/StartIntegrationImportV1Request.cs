using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Http;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Errors;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Imports
{
    /// <summary>
    /// Start integration import request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Post)]
    [Path(IntegrationImportV1Constants.StartRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class StartIntegrationImportV1Request : BaseRequest,
        IRequest<StartIntegrationImportV1Response>
    {
        /// <summary>
        /// Integration id
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "8FA615D4-6DE7-427E-9D65-CBDEFB4A3E1F")]
        [Required]
        public Guid? IntegrationId { get; set; }

        /// <summary>
        /// File version id
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "9AA13EF5-8547-4C75-BAD0-B9AF033EE552")]
        [Required]
        public Guid? FileVersionId { get; set; }

        /// <summary>
        /// File name
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue("example.xlsx")]
        [Required]
        public string FileName { get; set; }

        /// <summary>
        /// File size
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue(5000L)]
        [Required]
        public long? FileSize { get; set; }

        /// <summary>
        /// File date
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleString(ExampleStringKind.DateTimeOffset, "5/1/2008 8:06:32 AM +01:00")]
        [Required]
        public DateTimeOffset? FileDate { get; set; }
    }
}
