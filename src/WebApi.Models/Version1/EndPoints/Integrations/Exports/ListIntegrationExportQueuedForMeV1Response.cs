using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Exports
{
    /// <summary>
    /// List integration export queued for me response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListIntegrationExportQueuedForMeV1Response : BaseResponse
    {
        /// <summary>
        /// List of integration exports
        /// </summary>
        [DataMember]
        public IReadOnlyList<ListIntegrationExportQueuedForMeV1ResponseExport> Exports { get; set; }
            = Array.Empty<ListIntegrationExportQueuedForMeV1ResponseExport>();

        /// <summary>
        /// Total number of records matching the request
        /// </summary>
        [DataMember]
        [ExampleValue(Version1PageTotalConstants.Example)]
        [Range(Version1PageTotalConstants.Min, Version1PageTotalConstants.Max)]
        [Required]
        public int? Total { get; set; }
    }
}
