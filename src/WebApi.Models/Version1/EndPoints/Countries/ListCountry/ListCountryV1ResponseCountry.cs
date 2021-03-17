using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Countries.ListCountry
{
    /// <summary>
    /// List country item response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListCountryV1ResponseCountry
    {
        /// <summary>
        /// Country Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "23214CEE-0964-4E50-9538-3C5333B0935F")]
        [Required]
        public Guid? CountryId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [DataMember]
        [ExampleValue("Netherlands (the)")]
        [MaxLength(CountryV1Constants.ResponseNameLength)]
        public string Name { get; set; }

        /// <summary>
        /// Alpha 2 code
        /// </summary>
        [DataMember]
        [ExampleValue("NL")]
        [MaxLength(CountryV1Constants.Alpha2CodeLength)]
        [MinLength(CountryV1Constants.Alpha2CodeLength)]
        public string Alpha2Code { get; set; }

        /// <summary>
        /// Alpha 3 code
        /// </summary>
        [DataMember]
        [ExampleValue("NLD")]
        [MaxLength(CountryV1Constants.Alpha3CodeLength)]
        [MinLength(CountryV1Constants.Alpha3CodeLength)]
        public string Alpha3Code { get; set; }

        /// <summary>
        /// Numeric code
        /// </summary>
        [DataMember]
        [ExampleValue(528)]
        [Range(CountryV1Constants.MinNumericCode, CountryV1Constants.MaxNumericCode)]
        public int? NumericCode { get; set; }
    }
}
