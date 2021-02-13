using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version2.Constants;
using System;
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
        /// Equal
        /// </summary>
        [DataMember]
        [ExampleMember]
        public T? Equal { get; set; }
    }
}
