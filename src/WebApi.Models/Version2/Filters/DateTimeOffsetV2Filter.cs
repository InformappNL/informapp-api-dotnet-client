using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version2.Constants;
using System;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version2.Filters
{
    /// <summary>
    /// DateTimeOffset filter
    /// </summary>
    [DataContract(Namespace = Version2Constants.Namespace)]
    public class DateTimeOffsetV2Filter
    {
        /// <summary>
        /// Greater than
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? GreaterThan { get; set; }

        /// <summary>
        /// Greater than or equal
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? GreaterThanOrEqual { get; set; }

        /// <summary>
        /// Less than
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? LessThan { get; set; }

        /// <summary>
        /// Less than or equal
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? LessThanOrEqual { get; set; }

        /// <summary>
        /// Has value
        /// </summary>
        [DataMember]
        [ExampleValue(true)]
        public bool? HasValue { get; set; }
    }
}
