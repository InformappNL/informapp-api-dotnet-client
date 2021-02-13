using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.Filters
{
    /// <summary>
    /// String filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class StringV1Filter
    {
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
    }
}
