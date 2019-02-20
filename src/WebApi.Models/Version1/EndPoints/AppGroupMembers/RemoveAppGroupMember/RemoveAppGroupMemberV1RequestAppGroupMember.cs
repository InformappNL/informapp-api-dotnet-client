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
    public class RemoveAppGroupMemberV1RequestAppGroupMember
    {
        /// <summary>
        /// App group id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "E2BE830C-015D-4BE0-986C-3138B1C66386")]
        [Required]
        public Guid? AppGroupId { get; set; }

        /// <summary>
        /// App user id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "007ADE77-7374-492B-BBD4-6D12BF8E1F91")]
        [Required]
        public Guid? AppUserId { get; set; }
    }
}
