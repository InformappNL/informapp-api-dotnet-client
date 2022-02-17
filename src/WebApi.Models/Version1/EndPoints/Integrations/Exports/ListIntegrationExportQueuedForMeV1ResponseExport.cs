using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Exports
{
    /// <summary>
    /// Integration export
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListIntegrationExportQueuedForMeV1ResponseExport
    {
        /// <summary>
        /// Integration export Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "8711B622-061F-4FC5-A916-EB9135B0DBF1")]
        [Required]
        public Guid? IntegrationExportId { get; set; }

        /// <summary>
        /// Integration Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "32952475-A2C0-4C9C-9C07-07C9C63F7CBF")]
        [Required]
        public Guid? IntegrationId { get; set; }

        /// <summary>
        /// Attempt number
        /// </summary>
        [DataMember]
        [ExampleValue(1)]
        [Required]
        public int? AttemptNumber { get; set; }

        /// <summary>
        /// File name
        /// </summary>
        [DataMember]
        [ExampleValue("Orders.xlsx")]
        [MaxLength(IntegrationExportV1Constants.MaxFileNameLength)]
        [Required]
        public string FileName { get; set; }
    }
}
