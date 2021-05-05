using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats
{
    /// <summary>
    /// DataSource
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class CreateIntegrationUserHeartbeatV1RequestDataSource
    {
        /// <summary>
        /// DataSource Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "DEDC2AF7-CC8A-450B-AB48-28BA04E3F00B")]
        [Required]
        public Guid? DataSourceId { get; set; }
    }
}
