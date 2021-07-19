using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationEmails.ListFormRegistrationEmail
{
    /// <summary>
    /// Select columns
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public enum ListFormRegistrationEmailV1Select
    {
        /// <summary>
        /// All
        /// </summary>
        [EnumMember]
        All = 0,

        /// <summary>
        /// FormRegistrationId
        /// </summary>
        [EnumMember]
        FormRegistrationId = 1,

        /// <summary>
        /// EmailRecipients
        /// </summary>
        [EnumMember]
        EmailRecipients = 2,

        /// <summary>
        /// EmailFiles
        /// </summary>
        [EnumMember]
        EmailFiles = 3,
    }
}
