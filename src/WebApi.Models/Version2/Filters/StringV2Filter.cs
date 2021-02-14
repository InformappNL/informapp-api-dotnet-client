﻿using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version2.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version2.Filters
{
    /// <summary>
    /// String filter
    /// </summary>
    [DataContract(Namespace = Version2Constants.Namespace)]
    public class StringV2Filter
    {
        /// <summary>
        /// Equals
        /// </summary>
        [DataMember(Name = FilterV2Constants.Equal)]
        [ExampleValue("string")]
        public string Equal { get; set; }

        /// <summary>
        /// Starts with
        /// </summary>
        [DataMember]
        [ExampleValue("string")]
        public string StartsWith { get; set; }
    }
}
