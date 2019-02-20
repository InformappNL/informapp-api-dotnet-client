using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Customers.ListCustomer
{
    /// <summary>
    /// Customer
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListCustomerV1ResponseCustomer
    {
        /// <summary>
        /// Customer Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "3E00A05A-FF81-4523-80C1-F6837843C7A5")]
        [Required]
        public Guid? CustomerId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [DataMember]
        [ExampleValue("Building Inspectors N.V.")]
        [MaxLength(CustomerV1Constants.ResponseNameLength)]
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [DataMember]
        [ExampleValue("Building Inspectors Group")]
        [MaxLength(CustomerV1Constants.ResponseDescriptionLength)]
        public string Description { get; set; }

        /// <summary>
        /// Number
        /// </summary>
        [DataMember]
        [ExampleValue("18423")]
        [MaxLength(CustomerV1Constants.ResponseNumberLength)]
        public string Number { get; set; }

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
