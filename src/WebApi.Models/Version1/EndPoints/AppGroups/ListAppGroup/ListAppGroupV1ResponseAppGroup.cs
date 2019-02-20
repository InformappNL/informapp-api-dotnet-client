using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppGroups.ListAppGroup
{
    /// <summary>
    /// App group
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListAppGroupV1ResponseAppGroup
    {
        /// <summary>
        /// App group Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "078C75C2-1FCC-4070-A8EA-30146BF6E652")]
        [Required]
        public Guid? AppGroupId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [DataMember]
        [ExampleValue("Inspectors")]
        [MaxLength(AppGroupV1Constants.ResponseNameLength)]
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [DataMember]
        [ExampleValue("Inspectors")]
        [MaxLength(AppGroupV1Constants.ResponseDescriptionLength)]
        public string Description { get; set; }

        /// <summary>
        /// Business group Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "59B89B9E-1286-40C1-9C3C-5722292C2691")]
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
