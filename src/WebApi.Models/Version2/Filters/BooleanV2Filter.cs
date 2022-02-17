using ConnectedDevelopment.InformSystem.WebApi.Models.Version2.Constants;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version2.Filters
{
    /// <summary>
    /// Boolean filter
    /// </summary>
    [DataContract(Namespace = Version2Constants.Namespace)]
    public enum BooleanV2Filter
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
