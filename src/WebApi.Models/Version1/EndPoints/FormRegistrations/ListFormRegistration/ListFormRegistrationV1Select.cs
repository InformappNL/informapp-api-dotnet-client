using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrations.ListFormRegistration
{
    /// <summary>
    /// Select columns
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public enum ListFormRegistrationV1Select
    {
        /// <summary>
        /// All
        /// </summary>
        [EnumMember]
        All = 0,

        /// <summary>
        /// FormId
        /// </summary>
        [EnumMember]
        FormId = 1,

        /// <summary>
        /// SerialNumber
        /// </summary>
        [EnumMember]
        SerialNumber = 2,

        /// <summary>
        /// RegistrationDate
        /// </summary>
        [EnumMember]
        RegistrationDate = 3,

        /// <summary>
        /// CreditCount
        /// </summary>
        [EnumMember]
        CreditCount = 4,

        /// <summary>
        /// SentByUser
        /// </summary>
        [EnumMember]
        SentByUser = 5,

        /// <summary>
        /// CreateDate
        /// </summary>
        [EnumMember]
        CreateDate = 6,

        /// <summary>
        /// LastUpdateDate
        /// </summary>
        [EnumMember]
        LastUpdateDate = 7,
    }
}
