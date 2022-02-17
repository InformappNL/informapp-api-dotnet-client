using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrations.ListFormRegistration
{
    /// <summary>
    /// List form registration response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListFormRegistrationV1Response : BaseResponse
    {
        /// <summary>
        /// List of form registrations
        /// </summary>
        [DataMember]
        public IReadOnlyList<ListFormRegistrationV1ResponseRegistration> FormRegistrations { get; set; }
            = Array.Empty<ListFormRegistrationV1ResponseRegistration>();

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
