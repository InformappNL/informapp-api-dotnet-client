using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.Filters
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
        [DataMember(Name = FilterV1Constants.GreaterThanOrEqual)]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? GreaterThanOrEqual { get; set; }

        /// <summary>
        /// Less than or equal
        /// </summary>
        [DataMember(Name = FilterV1Constants.LessThanOrEqual)]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? LessThanOrEqual { get; set; }
    }
}
