using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Http;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Responses;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.Errors;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats
{
    /// <summary>
    /// Create integration user heartbeat request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Post)]
    [Path(IntegrationUserHeartbeatV1Constants.CreateRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class CreateIntegrationUserHeartbeatV1Request : BaseRequest,
        IRequest<CreateIntegrationUserHeartbeatV1Response>
    {
        /// <summary>
        /// Configuration
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue("{ \"DataSources\": { .. }, \"Integrations\": { .. }, \"CleanupFolder\": { .. } }")]
        [MaxLength(IntegrationUserHeartbeatV1Constants.ConfigurationLength)]
        [Required]
        public string Configuration { get; set; }

        /// <summary>
        /// Version
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue("1.0.0.0")]
        [MaxLength(IntegrationUserHeartbeatV1Constants.VersionLength)]
        [Required]
        public string Version { get; set; }

        /// <summary>
        /// Drives
        /// </summary>
        [BodyParameter]
        [DataMember]
        public IReadOnlyList<CreateIntegrationUserHeartbeatV1RequestDrive> Drives { get; set; }

        /// <summary>
        /// Data source enabled
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue(true)]
        [Required]
        public bool? DataSourceEnabled { get; set; }

        /// <summary>
        /// Data sources
        /// </summary>
        [BodyParameter]
        [DataMember]
        [Required]
        public IReadOnlyList<CreateIntegrationUserHeartbeatV1RequestDataSource> DataSources { get; set; }

        /// <summary>
        /// Integration enabled
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue(true)]
        [Required]
        public bool? IntegrationEnabled { get; set; }

        /// <summary>
        /// Integration default enabled
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue(true)]
        [Required]
        public bool? IntegrationDefaultEnabled { get; set; }

        /// <summary>
        /// Integrations
        /// </summary>
        [BodyParameter]
        [DataMember]
        [Required]
        public IReadOnlyList<CreateIntegrationUserHeartbeatV1RequestIntegration> Integrations { get; set; }
    }
}
