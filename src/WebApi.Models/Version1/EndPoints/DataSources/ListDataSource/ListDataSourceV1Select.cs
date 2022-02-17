using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.DataSources.ListDataSource
{
    /// <summary>
    /// Select columns
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public enum ListDataSourceV1Select
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
        /// Kind
        /// </summary>
        [EnumMember]
        Kind = 3,

        /// <summary>
        /// BusinessGroupId
        /// </summary>
        [EnumMember]
        BusinessGroupId = 4,

        /// <summary>
        /// CanBeUploaded
        /// </summary>
        [EnumMember]
        CanBeUploaded = 5,

        /// <summary>
        /// CreateDate
        /// </summary>
        [EnumMember]
        CreateDate = 6,

        /// <summary>
        /// LastUpdateDate
        /// </summary>
        [EnumMember]
        LastUpdateDate = 7,
    }
}
