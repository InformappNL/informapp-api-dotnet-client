using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Filters
{
    /// <summary>
    /// Primary Id filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class PrimaryIdV1Filter
    {
        /// <summary>
        /// Equal
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "D16F1006-0DF3-4D8F-9111-AAB7FEA69259")]
        public Guid? Equal { get; set; }
    }
}
