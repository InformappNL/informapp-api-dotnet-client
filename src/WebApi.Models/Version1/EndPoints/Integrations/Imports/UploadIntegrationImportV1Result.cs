using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Imports
{
    /// <summary>
    /// Download integration export result
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public enum UploadIntegrationImportV1Result
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
