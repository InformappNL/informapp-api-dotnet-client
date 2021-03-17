using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Users.ListUser
{
    /// <summary>
    /// User
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public partial class ListInformAppUserV1ResponseUser
    {
        /// <summary>
        /// Instruction id
        /// </summary>
        [DataMember]
        [ExampleValue("58e213fcf1396d37ce86bc1a")]
        [MaxLength(InformAppUserV1Constants.ResponseUserIdLength)]
        public string UserId { get; set; }

        /// <summary>
        /// App user id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "62AA9A2C-2110-4D85-8699-4936A8EFB997")]
        [Required]
        public Guid? AppUserId { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [DataMember]
        [ExampleValue("example@email")]
        [MaxLength(InformAppUserV1Constants.ResponseEmailLength)]
        public string Email { get; set; }
    }
}
