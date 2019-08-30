using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.Files
{
    /// <summary>
    /// File hash algorithm
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public enum FileV1HashAlgorithm
    {
        /// <summary>
        /// None
        /// </summary>
        [EnumMember]
        None = 0,

        /// <summary>
        /// MD5
        /// </summary>
        [EnumMember]
        MD5 = 1,

        /// <summary>
        /// RIPEMD160
        /// </summary>
        [EnumMember]
        RIPEMD160 = 2,

        /// <summary>
        /// SHA1
        /// </summary>
        [EnumMember]
        SHA1 = 3,

        /// <summary>
        /// SHA256
        /// </summary>
        [EnumMember]
        SHA256 = 4,

        /// <summary>
        /// SHA384
        /// </summary>
        [EnumMember]
        SHA384 = 5,

        /// <summary>
        /// SHA512
        /// </summary>
        [EnumMember]
        SHA512 = 6,
    }
}
