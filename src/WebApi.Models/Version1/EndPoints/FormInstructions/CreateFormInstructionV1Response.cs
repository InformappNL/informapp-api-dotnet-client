using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormInstructions
{
    /// <summary>
    /// Create form instruction response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public partial class CreateFormInstructionV1Response : BaseResponse
    {
        /// <summary>
        /// Form instruction id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "4B663902-8B23-47FE-BEDC-4A5D4A669401")]
        [MaxLength(FormInstructionV1Constants.ResponseFormInstructionIdLength)]
        [Required]
        public Guid? FormInstructionId { get; set; }

        /// <summary>
        /// Location of created form instruction
        /// </summary>
        [DataMember]
        [DataType(DataType.Url)]
        [ExampleString(ExampleStringKind.AbsoluteUri, "https://localhost/api/v1/forms/instructions/4B663902-8B23-47FE-BEDC-4A5D4A669401")]
        [Required]
        public Uri Location { get; set; }
    }
}
