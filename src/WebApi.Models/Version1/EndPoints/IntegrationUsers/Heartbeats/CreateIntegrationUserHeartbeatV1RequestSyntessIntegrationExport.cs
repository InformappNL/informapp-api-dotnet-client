using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats
{
    /// <summary>
    /// Syntess integration export
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class CreateIntegrationUserHeartbeatV1RequestSyntessIntegrationExport
    {
        /// <summary>
        /// Syntess integration export id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "CF81B5EA-8D8D-4E62-9B39-F1D361291468")]
        [Required]
        public Guid? SyntessIntegrationExportId { get; set; }
    }
}
