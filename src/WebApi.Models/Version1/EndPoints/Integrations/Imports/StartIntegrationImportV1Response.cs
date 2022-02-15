using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Imports
{
    /// <summary>
    /// Start integration import response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class StartIntegrationImportV1Response : BaseResponse
    {
        /// <summary>
        /// Integration import id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "02EAD820-839D-42FF-AE00-E1436802A92E")]
        [Required]
        public Guid? IntegrationImportId { get; set; }
    }
}
