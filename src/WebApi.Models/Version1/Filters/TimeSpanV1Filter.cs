using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.Filters
{
    /// <summary>
    /// TimeSpan filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class TimeSpanV1Filter
    {
        /// <summary>
        /// Greater than or equal
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.TimeSpanMinValue)]
        public TimeSpan? GreaterThanOrEqual { get; set; }

        /// <summary>
        /// Less than or equal
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.TimeSpanMaxValue)]
        public TimeSpan? LessThanOrEqual { get; set; }
    }
}
