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
    /// Enum filter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract(Namespace = Version2Constants.Namespace)]
    public partial class EnumV2Filter<T>
        where T : struct, Enum, IComparable, IFormattable, IConvertible
    {
        /// <summary>
        /// Kind
        /// </summary>
        [DataMember]
        [DefaultValue(EnumV2FilterKind.Any)]
        [EnumValidation(typeof(EnumV2FilterKind))]
        [ExampleValue(EnumV2FilterKind.Any)]
        public EnumV2FilterKind? Kind { get; set; } = EnumV2FilterKind.Any;

        /// <summary>
        /// Values
        /// </summary>
        [DataMember]
        [ExampleMember]
        [MaxItems(20)]
        public IReadOnlyList<T> Values { get; set; }

        /// <summary>
        /// Has value
        /// </summary>
        [DataMember]
        [ExampleValue(true)]
        public bool? HasValue { get; set; }
    }
}
