using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormDataNames
{
    /// <summary>
    /// List form data name response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListFormDataNameV1Response : BaseResponse
    {
        /// <summary>
        /// List of form data names
        /// </summary>
        [DataMember]
        public IReadOnlyList<ListFormDataNameV1ResponseFormDataName> FormDataNames { get; set; }
            = Array.Empty<ListFormDataNameV1ResponseFormDataName>();

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
