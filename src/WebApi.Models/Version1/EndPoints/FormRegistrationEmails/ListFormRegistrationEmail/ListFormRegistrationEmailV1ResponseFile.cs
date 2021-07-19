using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationEmails.ListFormRegistrationEmail
{
    /// <summary>
    /// Form registration file
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListFormRegistrationEmailV1ResponseFile
    {
        /// <summary>
        /// File Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "05E622D4-E8B2-4AE6-9250-D59DA8C6B790")]
        [Required]
        public Guid? FileId { get; set; }
    }
}
