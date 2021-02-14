using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.Filters;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.BusinessGroupCredits.ListBusinessGroupCredit
{
    /// <summary>
    /// List business group credit request filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListBusinessGroupCreditV1Filter
    {
        /// <summary>
        /// Filter records by customer id
        /// </summary>
        [DataMember]
        public IdV1Filter CustomerId { get; set; }

        /// <summary>
        /// Filter records by total registration count
        /// </summary>
        [DataMember]
        public Int32V1Filter TotalRegistrationCount { get; set; }

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
