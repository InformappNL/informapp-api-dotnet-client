using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Exports
{
    /// <summary>
    /// Accept integration export response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class AcceptIntegrationExportV1Response : BaseResponse
    {
        /// <summary>
        /// Integration export log id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "FED9F802-552A-4E1E-8DC4-1B99D4275429")]
        [Required]
        public Guid? IntegrationExportLogId { get; set; }
    }
}
