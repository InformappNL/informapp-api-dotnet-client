using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.AppUsers.GetAppUser
{
    /// <summary>
    /// App user response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class GetAppUserV1Response : BaseResponse
    {
        /// <summary>
        /// App user Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "EE1F7957-3402-45DC-93E4-6689B7E26776")]
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
        /// Business group id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "E72CBB26-B260-42B5-BBB3-60806A715F53")]
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
