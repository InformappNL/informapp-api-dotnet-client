using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.DataSources
{
    /// <summary>
    /// The kind of data source
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
#pragma warning disable CA1008 // Enums should have zero value
    public enum DataSourceV1Kind
#pragma warning restore CA1008 // Enums should have zero value
    {
        /// <summary>
        /// File
        /// </summary>
        [EnumMember]
        File = 1,
    }
}
