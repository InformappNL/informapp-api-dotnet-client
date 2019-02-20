using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationEmails.ListFormRegistrationEmail
{
    /// <summary>
    /// Form registration email
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListFormRegistrationEmailV1ResponseEmail
    {
        /// <summary>
        /// Form registration email Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "4ADAAF11-8B29-4B5D-861C-1F6D18B1672D")]
        [Required]
        public Guid? FormRegistrationEmailId { get; set; }

        /// <summary>
        /// Form registration Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "EB6A590C-2112-49D4-82BE-0C2E93411D8F")]
        public Guid? FormRegistrationId { get; set; }

        /// <summary>
        /// Email recipients
        /// </summary>
        [DataMember]
        public IEnumerable<ListFormRegistrationEmailV1ResponseRecipient> EmailRecipients { get; set; }
    }
}
