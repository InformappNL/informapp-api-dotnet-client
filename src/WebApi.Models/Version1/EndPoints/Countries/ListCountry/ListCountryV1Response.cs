using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Countries.ListCountry
{
    /// <summary>
    /// List country response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListCountryV1Response : BaseResponse
    {
        /// <summary>
        /// List of countries
        /// </summary>
        [DataMember]
        public IReadOnlyList<ListCountryV1ResponseCountry> Countries { get; set; }
            = Array.Empty<ListCountryV1ResponseCountry>();

        /// <summary>
        /// Total number of records matching the request
        /// </summary>
        [DataMember]
        [ExampleValue(CountryV1Constants.NumberOfCountries)]
        [Range(Version1PageTotalConstants.Min, Version1PageTotalConstants.Max)]
        [Required]
        public int? Total { get; set; }
    }
}
