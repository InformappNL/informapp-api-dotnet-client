using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.DataSources
{
    /// <summary>
    /// The kind of data source
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public enum DataSourceV1Kind
    {
        /// <summary>
        /// File
        /// </summary>
        [EnumMember]
        File = 1,
    }
}
