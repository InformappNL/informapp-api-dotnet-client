using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationData
{
    /// <summary>
    /// The kind of data
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public enum FormRegistrationDataV1Kind
    {
        /// <summary>
        /// Object
        /// </summary>
        [EnumMember]
        Object = 1,

        /// <summary>
        /// Array
        /// </summary>
        [EnumMember]
        Array = 2,

        /// <summary>
        /// Value
        /// </summary>
        [EnumMember]
        Value = 3
    }
}
