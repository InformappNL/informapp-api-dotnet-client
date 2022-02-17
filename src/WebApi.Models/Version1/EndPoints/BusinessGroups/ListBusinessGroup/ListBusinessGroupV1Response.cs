using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.BusinessGroups.ListBusinessGroup
{
    /// <summary>
    /// List business group response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListBusinessGroupV1Response : BaseResponse
    {
        /// <summary>
        /// List of business groups
        /// </summary>
        [DataMember]
        public IReadOnlyList<ListBusinessGroupV1ResponseBusinessGroup> BusinessGroups { get; set; }
            = Array.Empty<ListBusinessGroupV1ResponseBusinessGroup>();

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
