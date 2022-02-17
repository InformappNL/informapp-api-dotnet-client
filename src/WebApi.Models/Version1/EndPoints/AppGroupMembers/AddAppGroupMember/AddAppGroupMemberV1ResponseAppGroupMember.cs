using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.AppGroupMembers.AddAppGroupMember
{
    /// <summary>
    /// Member
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class AddAppGroupMemberV1ResponseAppGroupMember
    {
        /// <summary>
        /// App group id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "F54B1218-AC62-4E3E-BF94-E6D9FA0D4C5B")]
        [Required]
        public Guid? AppGroupId { get; set; }

        /// <summary>
        /// App user id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "C7F8BB98-31BD-41F1-93F0-678DD3C53B05")]
        [Required]
        public Guid? AppUserId { get; set; }
    }
}
