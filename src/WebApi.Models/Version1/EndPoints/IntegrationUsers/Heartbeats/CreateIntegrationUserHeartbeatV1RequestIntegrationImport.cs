using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats
{
    /// <summary>
    /// Integration import
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class CreateIntegrationUserHeartbeatV1RequestIntegrationImport
    {
        /// <summary>
        /// Integration Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "2DCC6E59-8430-4A7A-806C-6FD0987D353E")]
        [Required]
        public Guid? IntegrationId { get; set; }
    }
}
