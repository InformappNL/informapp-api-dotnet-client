using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats
{
    /// <summary>
    /// Create integration user heartbeat response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class CreateIntegrationUserHeartbeatV1Response : BaseResponse
    {
        /// <summary>
        /// Integration user heartbeat id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "BFAAE461-8755-4E81-8E68-183249367136")]
        [Required]
        public Guid? IntegrationUserHeartbeatId { get; set; }
    }
}
