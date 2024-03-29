﻿using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationData.ListFormRegistrationData
{
    /// <summary>
    /// List form registration data response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListFormRegistrationDataV1Response : BaseResponse
    {
        /// <summary>
        /// List of form registration data element
        /// </summary>
        [DataMember]
        public IReadOnlyList<ListFormRegistrationDataV1ResponseElement> FormRegistrationDataElements { get; set; }
            = Array.Empty<ListFormRegistrationDataV1ResponseElement>();

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
