using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.Filters;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrations.ListFormRegistration
{
    /// <summary>
    /// List form registration request filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListFormRegistrationV1Filter
    {
        /// <summary>
        /// Filter records by form id
        /// </summary>
        [DataMember]
        public IdV1Filter FormId { get; set; }

        /// <summary>
        /// Filter records by serial number
        /// </summary>
        [DataMember]
        public Int32V1Filter SerialNumber { get; set; }

        /// <summary>
        /// Filter records by registration date
        /// </summary>
        [DataMember]
        public DateTimeOffsetV1Filter RegistrationDate { get; set; }

        /// <summary>
        /// Filter records by credit count
        /// </summary>
        [DataMember]
        public Int32V1Filter CreditCount { get; set; }

        /// <summary>
        /// Filter records by sent by user
        /// </summary>
        [DataMember]
        public StringV1Filter SentByUser { get; set; }

        /// <summary>
        /// Filter records by create date
        /// </summary>
        [DataMember]
        public DateTimeOffsetV1Filter CreateDate { get; set; }

        /// <summary>
        /// Filter records by last update date
        /// </summary>
        [DataMember]
        public DateTimeOffsetV1Filter LastUpdateDate { get; set; }
    }
}
