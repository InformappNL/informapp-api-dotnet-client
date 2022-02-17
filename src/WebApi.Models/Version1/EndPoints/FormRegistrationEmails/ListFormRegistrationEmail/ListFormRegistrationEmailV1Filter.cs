using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Filters;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationEmails.ListFormRegistrationEmail
{
    /// <summary>
    /// List form registration email request filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListFormRegistrationEmailV1Filter
    {
        /// <summary>
        /// Filter records by form registration id
        /// </summary>
        [DataMember]
        public IdV1Filter FormRegistrationId { get; set; }

        /// <summary>
        /// Filter records by form id
        /// </summary>
        [DataMember]
        public IdV1Filter FormId { get; set; }

        /// <summary>
        /// Filter records by registration date
        /// </summary>
        [DataMember]
        public DateTimeOffsetV1Filter RegistrationDate { get; set; }
    }
}
