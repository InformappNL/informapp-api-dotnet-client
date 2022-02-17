using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Filters;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.BusinessGroups.ListBusinessGroup
{
    /// <summary>
    /// List business group request filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListBusinessGroupV1Filter
    {
        /// <summary>
        /// Filter records by customer id
        /// </summary>
        [DataMember]
        public IdV1Filter CustomerId { get; set; }

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
