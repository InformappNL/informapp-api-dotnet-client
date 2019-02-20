using Informapp.InformSystem.WebApi.Models.ExampleValues;
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
        /// Contains
        /// </summary>
        [DataMember]
        [ExampleValue("string")]
        public string Contains { get; set; }

        /// <summary>
        /// Equals
        /// </summary>
        [DataMember]
        [ExampleValue("string")]
        public string Equal { get; set; }

        /// <summary>
        /// Starts with
        /// </summary>
        [DataMember]
        [ExampleValue("string")]
        public string StartsWith { get; set; }

        /// <summary>
        /// Ends with
        /// </summary>
        [DataMember]
        [ExampleValue("string")]
        public string EndsWith { get; set; }

        /// <summary>
        /// Has value
        /// </summary>
        [DataMember]
        [ExampleValue(true)]
        public bool? HasValue { get; set; }
    }
}
