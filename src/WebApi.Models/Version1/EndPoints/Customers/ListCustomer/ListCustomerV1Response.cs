using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Customers.ListCustomer
{
    /// <summary>
    /// List customer response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListCustomerV1Response : BaseResponse
    {
        /// <summary>
        /// List of customers
        /// </summary>
        [DataMember]
        public IReadOnlyList<ListCustomerV1ResponseCustomer> Customers { get; set; }
            = Array.Empty<ListCustomerV1ResponseCustomer>();

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
