﻿using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Http;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Errors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats
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
        [ExampleValue("{ \"DataContext\": { .. }, \"DataSources\": { .. }, \"Integrations\": { .. }, \"IntegrationExports\": { .. }, \"IntegrationImports\": { .. }, \"CleanupFolder\": { .. } }")]
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
            = Array.Empty<CreateIntegrationUserHeartbeatV1RequestDataSource>();

        /// <summary>
        /// Integration export enabled
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue(true)]
        [Required]
        public bool? IntegrationEnabled { get; set; }

        /// <summary>
        /// Integration export default enabled
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue(true)]
        [Required]
        public bool? IntegrationDefaultEnabled { get; set; }

        /// <summary>
        /// Integration exports
        /// </summary>
        [BodyParameter]
        [DataMember]
        [Required]
        public IReadOnlyList<CreateIntegrationUserHeartbeatV1RequestIntegration> Integrations { get; set; }
            = Array.Empty<CreateIntegrationUserHeartbeatV1RequestIntegration>();

        /// <summary>
        /// Integration import enabled
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue(true)]
        //[Required]
        public bool? IntegrationImportEnabled { get; set; } = false;

        /// <summary>
        /// Integration imports
        /// </summary>
        [BodyParameter]
        [DataMember]
        //[Required]
        public IReadOnlyList<CreateIntegrationUserHeartbeatV1RequestIntegrationImport> IntegrationImports { get; set; }
            = Array.Empty<CreateIntegrationUserHeartbeatV1RequestIntegrationImport>();

        /// <summary>
        /// Syntess integration export enabled
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue(true)]
        //[Required]
        public bool? SyntessIntegrationExportEnabled { get; set; } = false;

        /// <summary>
        /// Syntess Integration exports
        /// </summary>
        [BodyParameter]
        [DataMember]
        //[Required]
        public IReadOnlyList<CreateIntegrationUserHeartbeatV1RequestSyntessIntegrationExport> SyntessIntegrationExports { get; set; }
            = Array.Empty<CreateIntegrationUserHeartbeatV1RequestSyntessIntegrationExport>();
    }
}
