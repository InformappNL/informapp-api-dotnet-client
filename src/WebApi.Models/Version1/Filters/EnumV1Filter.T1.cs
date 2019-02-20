using Informapp.InformSystem.WebApi.Models.DataAnnotations;
using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.Filters
{
    /// <summary>
    /// Enum filter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public partial class EnumV1Filter<T>
        where T : struct, IComparable, IFormattable, IConvertible
    {
        /// <summary>
        /// Kind
        /// </summary>
        [DataMember]
        [DefaultValue(EnumV1FilterKind.Any)]
        [EnumValidation(typeof(EnumV1FilterKind))]
        [ExampleValue(EnumV1FilterKind.Any)]
        public EnumV1FilterKind? Kind { get; set; } = EnumV1FilterKind.Any;

        /// <summary>
        /// Values
        /// </summary>
        [DataMember]
        [ExampleMember]
        [MaxItems(20)]
        public IEnumerable<T> Values { get; set; }

        /// <summary>
        /// Has value
        /// </summary>
        [DataMember]
        [ExampleValue(true)]
        public bool? HasValue { get; set; }
    }
}
