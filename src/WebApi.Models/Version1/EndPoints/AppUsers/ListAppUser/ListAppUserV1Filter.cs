using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.Filters;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppUsers.ListAppUser
{
    /// <summary>
    /// List app user request filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListAppUserV1Filter
    {
        /// <summary>
        /// Filter records by email
        /// </summary>
        [DataMember]
        public StringV1Filter Email { get; set; }

        /// <summary>
        /// Filter records by business group id
        /// </summary>
        [DataMember]
        public IdV1Filter BusinessGroupId { get; set; }

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
