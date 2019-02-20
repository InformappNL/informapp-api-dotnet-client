using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.BusinessGroups.ListBusinessGroup
{
    /// <summary>
    /// Business group
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListBusinessGroupV1ResponseBusinessGroup
    {
        /// <summary>
        /// Business group Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "B62F29FF-919A-4DA7-8DFE-2655850C53D4")]
        [Required]
        public Guid? BusinessGroupId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [DataMember]
        [ExampleValue("Business Group")]
        [MaxLength(BusinessGroupV1Constants.ResponseNameLength)]
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [DataMember]
        [ExampleValue("Business Group")]
        [MaxLength(BusinessGroupV1Constants.ResponseDescriptionLength)]
        public string Description { get; set; }

        /// <summary>
        /// Number
        /// </summary>
        [DataMember]
        [ExampleValue("BG1234")]
        [MaxLength(BusinessGroupV1Constants.ResponseNumberLength)]
        public string Number { get; set; }

        /// <summary>
        /// Customer id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "7D8AFB70-79E8-44C0-A819-9AC742506452")]
        public Guid? CustomerId { get; set; }

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
