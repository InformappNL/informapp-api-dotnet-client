using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Filters
{
    /// <summary>
    /// Id filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class IdV1Filter
    {
        /// <summary>
        /// Equal
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "3CB598B8-862B-45AC-93C4-85B30A773D8D")]
        public Guid? Equal { get; set; }
    }
}
