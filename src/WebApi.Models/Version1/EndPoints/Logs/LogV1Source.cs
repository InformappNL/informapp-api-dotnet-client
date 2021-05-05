using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Logs
{
    /// <summary>
    /// Application kind
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
#pragma warning disable CA1008 // Enums should have zero value
    public enum LogV1Source
#pragma warning restore CA1008 // Enums should have zero value
    {
        /// <summary>
        /// Web UI
        /// </summary>
        [EnumMember]
        WebUI = 1,

        /// <summary>
        /// Web Api
        /// </summary>
        [EnumMember]
        WebApi = 2,
    }
}
