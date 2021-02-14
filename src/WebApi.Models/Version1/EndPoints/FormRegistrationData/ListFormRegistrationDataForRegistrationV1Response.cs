using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationData
{
    /// <summary>
    /// List form registration data for registration response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListFormRegistrationDataForRegistrationV1Response : BaseResponse
    {
        /// <summary>
        /// List of form registration data element
        /// </summary>
        [DataMember]
        public IReadOnlyList<ListFormRegistrationDataForRegistrationV1ResponseElement> FormRegistrationDataElements { get; set; }
            = Array.Empty<ListFormRegistrationDataForRegistrationV1ResponseElement>();

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
