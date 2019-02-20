using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.Filters;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppGroupMembers.ListAppGroupMember
{
    /// <summary>
    /// List app group member request filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListAppGroupMemberV1Filter
    {
        /// <summary>
        /// Filter records by app group id
        /// </summary>
        [DataMember]
        public IdV1Filter AppGroupId { get; set; }

        /// <summary>
        /// Filter records by app user id
        /// </summary>
        [DataMember]
        public IdV1Filter AppUserId { get; set; }

        /// <summary>
        /// Filter records by create date
        /// </summary>
        [DataMember]
        public DateTimeOffsetV1Filter CreateDate { get; set; }
    }
}
