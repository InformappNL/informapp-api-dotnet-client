using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationData
{
    /// <summary>
    /// Select columns
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public enum ListFormRegistrationDataForRegistrationV1Select
    {
        /// <summary>
        /// All
        /// </summary>
        [EnumMember]
        All = 0,

        /// <summary>
        /// ParentFormRegistrationDataElementId
        /// </summary>
        [EnumMember]
        ParentFormRegistrationDataElementId = 2,

        /// <summary>
        /// Depth
        /// </summary>
        [EnumMember]
        Depth = 3,

        /// <summary>
        /// Index
        /// </summary>
        [EnumMember]
        Index = 4,

        /// <summary>
        /// Order
        /// </summary>
        [EnumMember]
        Order = 5,

        /// <summary>
        /// Kind
        /// </summary>
        [EnumMember]
        Kind = 6,

        /// <summary>
        /// Name
        /// </summary>
        [EnumMember]
        Name = 7,

        /// <summary>
        /// Path
        /// </summary>
        [EnumMember]
        Path = 8,

        /// <summary>
        /// Value text
        /// </summary>
        [EnumMember]
        ValueText = 9,

        /// <summary>
        /// Value boolean
        /// </summary>
        [EnumMember]
        ValueBoolean = 10,

        /// <summary>
        /// Value integer
        /// </summary>
        [EnumMember]
        ValueInteger = 11,

        /// <summary>
        /// Value decimal
        /// </summary>
        [EnumMember]
        ValueDecimal = 12,

        /// <summary>
        /// Value date
        /// </summary>
        [EnumMember]
        ValueDate = 13,

        /// <summary>
        /// Value time
        /// </summary>
        [EnumMember]
        ValueTime = 14,

        /// <summary>
        /// Value UUID
        /// </summary>
        [EnumMember]
        ValueUuid = 15,

        /// <summary>
        /// FullName
        /// </summary>
        [EnumMember]
        FullName = 16,
    }
}
