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
    public class AddAppGroupMemberV1RequestAppGroupMember
    {
        /// <summary>
        /// App group id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "14C1632F-6A67-4DFE-9469-12212D81DFC7")]
        [Required]
        public Guid? AppGroupId { get; set; }

        /// <summary>
        /// App user id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "DF9A67D1-2F21-4B68-9896-127FAC24F877")]
        [Required]
        public Guid? AppUserId { get; set; }
    }
}
