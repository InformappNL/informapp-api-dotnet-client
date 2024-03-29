﻿using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationStats.ListFormRegistrationStats
{
    /// <summary>
    /// List form registration stats response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListFormRegistrationStatsV1Response : BaseResponse
    {
        /// <summary>
        /// List of form registration stats
        /// </summary>
        [DataMember]
        public IReadOnlyList<ListFormRegistrationStatsV1ResponseFormRegistrationStats> FormRegistrationStats { get; set; }
            = Array.Empty<ListFormRegistrationStatsV1ResponseFormRegistrationStats>();

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
