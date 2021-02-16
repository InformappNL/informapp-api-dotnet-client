using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.Filters
{
    /// <summary>
    /// Enum filter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public partial class EnumV1Filter<T>
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
