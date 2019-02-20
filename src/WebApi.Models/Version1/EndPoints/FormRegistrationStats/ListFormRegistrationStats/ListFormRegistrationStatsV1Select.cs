using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationStats.ListFormRegistrationStats
{
    /// <summary>
    /// Select columns
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public enum ListFormRegistrationStatsV1Select
    {
        /// <summary>
        /// All
        /// </summary>
        [EnumMember]
        All = 0,

        /// <summary>
        /// Name
        /// </summary>
        [EnumMember]
        RegistrationCount = 1,

        /// <summary>
        /// Description
        /// </summary>
        [EnumMember]
        HighestSerialNumber = 2,

        /// <summary>
        /// CreateDate
        /// </summary>
        [EnumMember]
        CreateDate = 3,

        /// <summary>
        /// LastUpdateDate
        /// </summary>
        [EnumMember]
        LastUpdateDate = 4,

        /// <summary>
        /// BusinessGroupId
        /// </summary>
        [EnumMember]
        BusinessGroupId = 5,
    }
}
