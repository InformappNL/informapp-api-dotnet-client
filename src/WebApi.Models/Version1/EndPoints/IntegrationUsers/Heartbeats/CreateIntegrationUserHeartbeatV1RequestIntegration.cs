using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats
{
    /// <summary>
    /// Integration
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
