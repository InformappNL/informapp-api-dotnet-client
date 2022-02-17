using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationData
{
    /// <summary>
    /// The kind of data
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
#pragma warning disable CA1008 // Enums should have zero value
    public enum FormRegistrationDataV1Kind
#pragma warning restore CA1008 // Enums should have zero value
    {
        /// <summary>
        /// Dictionary
        /// </summary>
        [EnumMember]
        Dictionary = 1,

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
