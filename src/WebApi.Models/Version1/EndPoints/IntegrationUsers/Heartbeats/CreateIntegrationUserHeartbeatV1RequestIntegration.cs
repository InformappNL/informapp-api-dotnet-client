using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats
{
    /// <summary>
    /// Integration export
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class CreateIntegrationUserHeartbeatV1RequestIntegration
    {
        /// <summary>
        /// Integration Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "F7A7D62F-BA5B-42BF-B432-77E47D0F51FC")]
        [Required]
        public Guid? IntegrationId { get; set; }
    }
}
