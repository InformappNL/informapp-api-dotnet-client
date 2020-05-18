using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.BusinessGroupCredits.ListBusinessGroupCredit
{
    /// <summary>
    /// Select columns
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public enum ListBusinessGroupCreditV1Select
    {
        /// <summary>
        /// All
        /// </summary>
        [EnumMember]
        All = 0,

        /// <summary>
        /// TotalRegistrationCount
        /// </summary>
        [EnumMember]
        TotalRegistrationCount = 1,

        /// <summary>
        /// CreateDate
        /// </summary>
        [EnumMember]
        CreateDate = 2,

        /// <summary>
        /// LastUpdateDate
        /// </summary>
        [EnumMember]
        LastUpdateDate = 3,
    }
}
