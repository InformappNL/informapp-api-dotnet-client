using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.AppGroupMembers.ListAppGroupMember
{
    /// <summary>
    /// List app group member response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListAppGroupMemberV1Response : BaseResponse
    {
        /// <summary>
        /// List of app group members
        /// </summary>
        [DataMember]
        public IReadOnlyList<ListAppGroupMemberV1ResponseAppGroupMember> AppGroupMembers { get; set; }
            = Array.Empty<ListAppGroupMemberV1ResponseAppGroupMember>();

        /// <summary>
        /// Total number of records matching the request
        /// </summary>
        [DataMember]
        [ExampleValue(Version1PageTotalConstants.Example)]
        [Range(Version1PageTotalConstants.Min, Version1PageTotalConstants.Max)]
        [Required]
        public int? Total { get; set; }
    }
}
