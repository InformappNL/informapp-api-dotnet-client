using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.Filters
{
    /// <summary>
    /// Enum filter kind
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public enum EnumV1FilterKind
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
