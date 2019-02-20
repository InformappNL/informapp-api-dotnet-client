using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppGroupMembers.RemoveAppGroupMember
{
    /// <summary>
    /// Member
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class RemoveAppGroupMemberV1ResponseAppGroupMember
    {
        /// <summary>
        /// App group id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "7A51DA7E-9CF0-48AB-B512-F447EDFF82BC")]
        [Required]
        public Guid? AppGroupId { get; set; }

        /// <summary>
        /// App user id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "6BF0812A-1798-4E5E-90EA-204B3FE7953B")]
        [Required]
        public Guid? AppUserId { get; set; }
    }
}
