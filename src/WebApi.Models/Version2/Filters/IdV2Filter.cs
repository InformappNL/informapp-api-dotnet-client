using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version2.Constants;
using System;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version2.Filters
{
    /// <summary>
    /// Id filter
    /// </summary>
    [DataContract(Namespace = Version2Constants.Namespace)]
    public class IdV2Filter
    {
        /// <summary>
        /// Equal
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "3CB598B8-862B-45AC-93C4-85B30A773D8D")]
        public Guid? Equal { get; set; }
    }
}
