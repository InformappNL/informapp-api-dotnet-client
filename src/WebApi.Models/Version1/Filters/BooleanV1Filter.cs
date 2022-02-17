using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Filters
{
    /// <summary>
    /// Boolean filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public enum BooleanV1Filter
    {
        /// <summary>
        /// False
        /// </summary>
        [EnumMember]
        False = 0,

        /// <summary>
        /// True
        /// </summary>
        [EnumMember]
        True = 1,

        /// <summary>
        /// True or false
        /// </summary>
        [EnumMember]
        TrueOrFalse = 2,

        /// <summary>
        /// No value
        /// </summary>
        [EnumMember]
        NoValue = 3,
    }
}
