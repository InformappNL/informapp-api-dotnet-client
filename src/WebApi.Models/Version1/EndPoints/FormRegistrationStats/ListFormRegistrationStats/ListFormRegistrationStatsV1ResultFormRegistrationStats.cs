using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationStats.ListFormRegistrationStats
{
    /// <summary>
    /// Form registration stats
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListFormRegistrationStatsV1ResultFormRegistrationStats
    {
        /// <summary>
        /// Form Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "ECC808A2-B356-49D7-8D09-C03B40A5AE7D")]
        [Required]
        public Guid? FormId { get; set; }

        /// <summary>
        /// Registration count
        /// </summary>
        [DataMember]
        [ExampleValue(42)]
        public int? RegistrationCount { get; set; }

        /// <summary>
        /// Highest serial number
        /// </summary>
        [DataMember]
        [ExampleValue(42)]
        public int? HighestSerialNumber { get; set; }

        /// <summary>
        /// Business group id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "8443235C-A450-42A2-8F99-2EB1C6341778")]
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
