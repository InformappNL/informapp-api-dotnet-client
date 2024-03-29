﻿using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Forms.ListForm
{
    /// <summary>
    /// List form response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListFormV1Response : BaseResponse
    {
        /// <summary>
        /// List of forms
        /// </summary>
        [DataMember]
        public IReadOnlyList<ListFormV1ResponseForm> Forms { get; set; }
            = Array.Empty<ListFormV1ResponseForm>();

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
