using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Filters
{
    /// <summary>
    /// Guid filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class GuidV1Filter
    {
        /// <summary>
        /// Equal
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "EA07E733-54AA-4CAF-BDAF-058C97F4599F")]
        public Guid? Equal { get; set; }
    }
}
