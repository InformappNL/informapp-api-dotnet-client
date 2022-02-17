using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version2.Constants;
using System;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version2.Filters
{
    /// <summary>
    /// DateTimeOffset filter
    /// </summary>
    [DataContract(Namespace = Version2Constants.Namespace)]
    public class DateTimeOffsetV2Filter
    {
        /// <summary>
        /// Greater than or equal
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? GreaterThanOrEqual { get; set; }

        /// <summary>
        /// Less than or equal
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? LessThanOrEqual { get; set; }
    }
}
