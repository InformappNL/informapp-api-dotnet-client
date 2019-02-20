using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.BusinessGroupCredits.ListBusinessGroupCredit
{
    /// <summary>
    /// Business group credit
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListBusinessGroupCreditV1ResponseBusinessGroupCredit
    {
        /// <summary>
        /// Business group Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "FE574B61-56E8-45A8-B504-78916E8297D4")]
        [Required]
        public Guid? BusinessGroupId { get; set; }

        /// <summary>
        /// Total number of form registrations
        /// </summary>
        [DataMember]
        [ExampleValue(2900)]
        [Range(BusinessGroupCreditV1Constants.TotalRegistrationCountMin, BusinessGroupCreditV1Constants.TotalRegistrationCountMax)]
        public int? TotalRegistrationCount { get; set; }

        /// <summary>
        /// Total available credits
        /// </summary>
        [DataMember]
        [ExampleValue(100)]
        [Range(BusinessGroupCreditV1Constants.TotalAvailableCreditsMin, BusinessGroupCreditV1Constants.TotalAvailableCreditsMax)]
        public int? TotalAvailableCredits { get; set; }

        /// <summary>
        /// Total credits of non empty bundles
        /// </summary>
        [DataMember]
        [ExampleValue(300)]
        [Range(BusinessGroupCreditV1Constants.TotalCreditsOfNonEmptyBundlesMin, BusinessGroupCreditV1Constants.TotalCreditsOfNonEmptyBundlesMax)]
        public int? TotalCreditsOfNonEmptyBundles { get; set; }

        /// <summary>
        /// Total credits
        /// </summary>
        [DataMember]
        [ExampleValue(3000)]
        [Range(BusinessGroupCreditV1Constants.TotalCreditsMin, BusinessGroupCreditV1Constants.TotalCreditsMax)]
        public int? TotalCredits { get; set; }

        /// <summary>
        /// Total pending credits, purchased but not yet added
        /// </summary>
        [DataMember]
        [ExampleValue(100)]
        [Range(BusinessGroupCreditV1Constants.TotalPendingCreditsMin, BusinessGroupCreditV1Constants.TotalPendingCreditsMax)]
        public int? TotalPendingCredits { get; set; }

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
