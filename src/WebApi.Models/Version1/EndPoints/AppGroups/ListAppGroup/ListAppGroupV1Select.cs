using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.AppGroups.ListAppGroup
{
    /// <summary>
    /// Select columns
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public enum ListAppGroupV1Select
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
        Name = 1,

        /// <summary>
        /// Description
        /// </summary>
        [EnumMember]
        Description = 2,

        /// <summary>
        /// BusinessGroupId
        /// </summary>
        [EnumMember]
        BusinessGroupId = 3,

        /// <summary>
        /// CreateDate
        /// </summary>
        [EnumMember]
        CreateDate = 4,

        /// <summary>
        /// LastUpdateDate
        /// </summary>
        [EnumMember]
        LastUpdateDate = 5,
    }
}
