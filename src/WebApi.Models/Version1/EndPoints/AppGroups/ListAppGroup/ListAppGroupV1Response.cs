using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.AppGroups.ListAppGroup
{
    /// <summary>
    /// List app group response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListAppGroupV1Response : BaseResponse
    {
        /// <summary>
        /// List of app groups
        /// </summary>
        [DataMember]
        public IReadOnlyList<ListAppGroupV1ResponseAppGroup> AppGroups { get; set; }
            = Array.Empty<ListAppGroupV1ResponseAppGroup>();

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
