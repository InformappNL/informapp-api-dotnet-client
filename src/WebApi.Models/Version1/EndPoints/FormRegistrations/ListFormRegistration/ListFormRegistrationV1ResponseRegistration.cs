using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrations.ListFormRegistration
{
    /// <summary>
    /// Form registration
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListFormRegistrationV1ResponseRegistration
    {
        /// <summary>
        /// Form registration Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "BD69DA16-8CD9-4CA9-8BA3-CBE815227382")]
        [Required]
        public Guid? FormRegistrationId { get; set; }

        /// <summary>
        /// Form Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "25715CD4-1F9F-4AC6-BD62-12E592EAB3F5")]
        public Guid? FormId { get; set; }

        /// <summary>
        /// Registration serial number, unique per form
        /// </summary>
        [DataMember]
        [ExampleValue(16)]
        [Range(FormRegistrationV1Constants.SerialNumberMin, FormRegistrationV1Constants.SerialNumberMax)]
        public int? SerialNumber { get; set; }

        /// <summary>
        /// Registration date
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetUtcNow)]
        public DateTimeOffset? RegistrationDate { get; set; }

        /// <summary>
        /// Sent by user
        /// </summary>
        [DataMember]
        [EmailAddress]
        [ExampleValue(Version1Examples.Email)]
        [MaxLength(FormRegistrationV1Constants.ResponseSentByUserLength)]
        public string SentByUser { get; set; }

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
