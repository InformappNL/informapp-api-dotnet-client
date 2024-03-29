﻿using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.AppUsers.ListAppUser
{
    /// <summary>
    /// Select columns
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public enum ListAppUserV1Select
    {
        /// <summary>
        /// All
        /// </summary>
        [EnumMember]
        All = 0,

        /// <summary>
        /// Email
        /// </summary>
        [EnumMember]
        Email = 1,

        /// <summary>
        /// BusinessGroupId
        /// </summary>
        [EnumMember]
        BusinessGroupId = 2,

        /// <summary>
        /// CreateDate
        /// </summary>
        [EnumMember]
        CreateDate = 3,

        /// <summary>
        /// LastUpdateDate
        /// </summary>
        [EnumMember]
        LastUpdateDate = 4,
    }
}
