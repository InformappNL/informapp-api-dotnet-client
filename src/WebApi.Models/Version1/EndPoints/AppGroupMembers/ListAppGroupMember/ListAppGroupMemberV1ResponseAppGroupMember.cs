using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppGroupMembers.ListAppGroupMember
{
    /// <summary>
    /// App group member
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListAppGroupMemberV1ResponseAppGroupMember
    {
        /// <summary>
        /// App group Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "10FE9475-B5F0-4FB3-A225-41A2B3F01983")]
        [Required]
        public Guid? AppGroupId { get; set; }

        /// <summary>
        /// App user Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "96EAEAA2-0523-4803-80F1-4C79F91827AF")]
        [Required]
        public Guid? AppUserId { get; set; }

        /// <summary>
        /// Create date
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? CreateDate { get; set; }
    }
}
