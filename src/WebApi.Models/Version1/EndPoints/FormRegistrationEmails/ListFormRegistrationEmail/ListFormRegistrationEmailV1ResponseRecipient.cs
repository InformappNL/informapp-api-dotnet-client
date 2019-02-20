using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationEmails.ListFormRegistrationEmail
{
    /// <summary>
    /// Form registration email recipient
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListFormRegistrationEmailV1ResponseRecipient
    {
        /// <summary>
        /// Email address
        /// </summary>
        [DataMember]
        [EmailAddress]
        [ExampleValue(Version1Examples.Email)]
        [MaxLength(FormRegistrationEmailV1Constants.ResponseEmailLength)]
        [Required]
        public string Email { get; set; }
    }
}
