﻿using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Filters;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.AppGroups.ListAppGroup
{
    /// <summary>
    /// List app group request filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListAppGroupV1Filter
    {
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
