using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Values
{
    /// <summary>
    /// Values kind
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public enum ValuesV1Kind
    {
        /// <summary>
        /// Zero
        /// </summary>
        [EnumMember]
        Zero = 0,

        /// <summary>
        /// One
        /// </summary>
        [EnumMember]
        One = 1,

        /// <summary>
        /// Two
        /// </summary>
        [EnumMember]
        Two = 2,

        /// <summary>
        /// Three
        /// </summary>
        [EnumMember]
        Three = 3,

        /// <summary>
        /// Four
        /// </summary>
        [EnumMember]
        Four = 4
    }
}
