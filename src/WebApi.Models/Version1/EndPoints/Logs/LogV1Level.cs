using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Logs
{
    /// <summary>
    /// Log level
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public enum LogV1Level
    {
        /// <summary>
        /// Off
        /// </summary>
        [EnumMember]
        Off = 0,

        /// <summary>
        /// Fatal
        /// </summary>
        [EnumMember]
        Fatal = 1,

        /// <summary>
        /// Error
        /// </summary>
        [EnumMember]
        Error = 2,

        /// <summary>
        /// Warn
        /// </summary>
        [EnumMember]
        Warn = 3,

        /// <summary>
        /// Info
        /// </summary>
        [EnumMember]
        Info = 4,

        /// <summary>
        /// Debug
        /// </summary>
        [EnumMember]
        Debug = 5,
    }
}
