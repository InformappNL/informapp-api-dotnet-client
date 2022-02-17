using ConnectedDevelopment.InformSystem.WebApi.Models.DataAnnotations;
using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.DataSources.ListDataSource
{
    /// <summary>
    /// Data source
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListDataSourceV1ResponseDataSource
    {
        /// <summary>
        /// Data source Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "1223FBBB-4FA1-4361-AFAF-14234FCF59C5")]
        [Required]
        public Guid? DataSourceId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [DataMember]
        [ExampleValue("Projects")]
        [MaxLength(DataSourceV1Constants.ResponseNameLength)]
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [DataMember]
        [ExampleValue("Data source for active customer projects")]
        [MaxLength(DataSourceV1Constants.ResponseDescriptionLength)]
        public string Description { get; set; }

        /// <summary>
        /// Kind
        /// </summary>
        [DataMember]
        [EnumValidation(typeof(DataSourceV1Kind))]
        [ExampleValue(DataSourceV1Kind.File)]
        public DataSourceV1Kind? Kind { get; set; }

        /// <summary>
        /// Business group Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "23078DCD-A5BA-4CEF-9AF2-250758E395C2")]
        public Guid? BusinessGroupId { get; set; }

        /// <summary>
        /// Indicates whether a file can be uploaded to the datasource
        /// </summary>
        [DataMember]
        [ExampleValue(true)]
        public bool? CanBeUploaded { get; set; }

        /// <summary>
        /// Create date
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? CreateDate { get; set; }

        /// <summary>
        /// Last update date
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? LastUpdateDate { get; set; }
    }
}
