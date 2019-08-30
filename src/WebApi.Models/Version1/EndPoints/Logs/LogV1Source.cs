using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Logs
{
    /// <summary>
    /// Application kind
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public enum LogV1Source
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
