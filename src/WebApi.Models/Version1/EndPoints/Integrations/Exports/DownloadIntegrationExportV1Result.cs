using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Exports
{
    /// <summary>
    /// Download integration export result
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public enum DownloadIntegrationExportV1Result
    {
        /// <summary>
        /// Success
        /// </summary>
        [EnumMember]
        Success = 0,

        /// <summary>
        /// Failed
        /// </summary>
        [EnumMember]
        Failed = 1,
    }
}
