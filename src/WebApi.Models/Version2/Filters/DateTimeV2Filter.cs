using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version2.Constants;
using System;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version2.Filters
{
    /// <summary>
    /// DateTime filter
    /// </summary>
    [DataContract(Namespace = Version2Constants.Namespace)]
    public class DateTimeV2Filter
    {
        /// <summary>
        /// Greater than
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeNow)]
        public DateTime? GreaterThan { get; set; }

        /// <summary>
        /// Greater than or equal
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeNow)]
        public DateTime? GreaterThanOrEqual { get; set; }

        /// <summary>
        /// Less than
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeNow)]
        public DateTime? LessThan { get; set; }

        /// <summary>
        /// Less than or equal
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeNow)]
        public DateTime? LessThanOrEqual { get; set; }

        /// <summary>
        /// Has value
        /// </summary>
        [DataMember]
        [ExampleValue(true)]
        public bool? HasValue { get; set; }
    }
}
