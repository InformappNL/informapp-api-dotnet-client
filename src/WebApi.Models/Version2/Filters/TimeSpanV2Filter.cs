﻿using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version2.Constants;
using System;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version2.Filters
{
    /// <summary>
    /// TimeSpan filter
    /// </summary>
    [DataContract(Namespace = Version2Constants.Namespace)]
    public class TimeSpanV2Filter
    {
        /// <summary>
        /// Greater than
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.TimeSpanMinValue)]
        public TimeSpan? GreaterThan { get; set; }

        /// <summary>
        /// Greater than or equal
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.TimeSpanMinValue)]
        public TimeSpan? GreaterThanOrEqual { get; set; }

        /// <summary>
        /// Less than
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.TimeSpanMaxValue)]
        public TimeSpan? LessThan { get; set; }

        /// <summary>
        /// Less than or equal
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.TimeSpanMaxValue)]
        public TimeSpan? LessThanOrEqual { get; set; }

        /// <summary>
        /// Has value
        /// </summary>
        [DataMember]
        [ExampleValue(true)]
        public bool? HasValue { get; set; }
    }
}
