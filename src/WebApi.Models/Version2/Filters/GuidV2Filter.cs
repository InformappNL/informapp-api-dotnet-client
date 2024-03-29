﻿using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version2.Constants;
using System;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version2.Filters
{
    /// <summary>
    /// Guid filter
    /// </summary>
    [DataContract(Namespace = Version2Constants.Namespace)]
    public class GuidV2Filter
    {
        /// <summary>
        /// Equal
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "EA07E733-54AA-4CAF-BDAF-058C97F4599F")]
        public Guid? Equal { get; set; }
    }
}
