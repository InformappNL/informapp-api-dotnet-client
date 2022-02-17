using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Forms.ListForm
{
    /// <summary>
    /// Form
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListFormV1ResponseForm
    {
        /// <summary>
        /// Form Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "D28CAB53-D69B-448C-91E5-5D52FEF1A42F")]
        [Required]
        public Guid? FormId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [DataMember]
        [ExampleValue("Time registration")]
        [MaxLength(FormV1Constants.ResponseNameLength)]
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [DataMember]
        [ExampleValue("Time registration form for inspectors")]
        [MaxLength(FormV1Constants.ResponseDescriptionLength)]
        public string Description { get; set; }

        /// <summary>
        /// Number
        /// </summary>
        [DataMember]
        [ExampleValue("R5464")]
        [MaxLength(FormV1Constants.ResponseNumberLength)]
        public string Number { get; set; }

        /// <summary>
        /// Business group id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "5A34697A-FF33-4FC5-9248-1BDE1BFBD77A")]
        public Guid? BusinessGroupId { get; set; }

        /// <summary>
        /// Create date
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? CreateDate { get; set; }

        /// <summary>
        /// Last update date
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? LastUpdateDate { get; set; }
    }
}
