using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Filters
{
    /// <summary>
    /// DateTimeOffset filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class DateTimeOffsetV1Filter
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
