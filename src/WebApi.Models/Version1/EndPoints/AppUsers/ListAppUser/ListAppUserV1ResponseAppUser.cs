using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.AppUsers.ListAppUser
{
    /// <summary>
    /// App user
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListAppUserV1ResponseAppUser
    {
        /// <summary>
        /// App user Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "078C75C2-1FCC-4070-A8EA-30146BF6E652")]
        [Required]
        public Guid? AppUserId { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [DataMember]
        [EmailAddress]
        [ExampleValue(Version1Examples.Email)]
        [MaxLength(AppUserV1Constants.ResponseEmailLength)]
        public string Email { get; set; }

        /// <summary>
        /// Business group Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "B020170D-743D-483B-B455-99812413D41D")]
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
