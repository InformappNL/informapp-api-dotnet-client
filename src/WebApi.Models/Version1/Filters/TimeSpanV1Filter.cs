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
        [DataMember(Name = FilterV1Constants.GreaterThanOrEqual)]
        [ExampleConstant(ExampleConstantKind.TimeSpanMinValue)]
        public TimeSpan? GreaterThanOrEqual { get; set; }

        /// <summary>
        /// Less than or equal
        /// </summary>
        [DataMember(Name = FilterV1Constants.LessThanOrEqual)]
        [ExampleConstant(ExampleConstantKind.TimeSpanMaxValue)]
        public TimeSpan? LessThanOrEqual { get; set; }
    }
}
