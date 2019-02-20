using Informapp.InformSystem.WebApi.Models.Version2.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version2.Filters
{
    /// <summary>
    /// Enum filter kind
    /// </summary>
    [DataContract(Namespace = Version2Constants.Namespace)]
    public enum EnumV2FilterKind
    {
        /// <summary>
        /// Any
        /// </summary>
        [EnumMember]
        Any = 0,

        /// <summary>
        /// None
        /// </summary>
        [EnumMember]
        None = 1,
    }
}
