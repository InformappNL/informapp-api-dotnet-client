using Informapp.InformSystem.WebApi.Models.DataAnnotations;
using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version2.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version2.Filters
{
    /// <summary>
    /// Guid filter
    /// </summary>
    [DataContract(Namespace = Version2Constants.Namespace)]
    public partial class GuidV2Filter
    {
        /// <summary>
        /// Filter records with (true) or without (false) a value from Values
        /// </summary>
        [DataMember]
        [DefaultValue(true)]
        [ExampleValue(true)]
        public bool? ValuesContains { get; set; } = true;

        /// <summary>
        /// Values
        /// </summary>
        [DataMember]
        [ExampleMemberProvider(typeof(GuidV2Filter), nameof(Values))]
        [MaxItems(10)]
        [UniqueItems(typeof(Guid))]
        public IEnumerable<Guid> Values { get; set; }

        /// <summary>
        /// Has value
        /// </summary>
        [DataMember]
        [ExampleValue(true)]
        public bool? HasValue { get; set; }
    }
}
