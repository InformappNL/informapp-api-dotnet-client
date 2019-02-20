using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version2.Constants;
using System;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version2.Filters
{
    /// <summary>
    /// Primary Id filter
    /// </summary>
    [DataContract(Namespace = Version2Constants.Namespace)]
    public class PrimaryIdV2Filter
    {
        /// <summary>
        /// Equal
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "FC4225C2-B86C-4CE7-8D8B-69199C6CF1F1")]
        public Guid? Equal { get; set; }

    }
}
