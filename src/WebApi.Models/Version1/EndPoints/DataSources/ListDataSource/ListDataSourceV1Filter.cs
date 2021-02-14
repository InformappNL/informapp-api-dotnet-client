using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.Filters;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.DataSources.ListDataSource
{
    /// <summary>
    /// List data source request filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListDataSourceV1Filter
    {
        /// <summary>
        /// Filter records by business group id
        /// </summary>
        [DataMember]
        public IdV1Filter BusinessGroupId { get; set; }

        /// <summary>
        /// Filter records by whether a file can be uploaded
        /// </summary>
        [DataMember]
        [ExampleValue(true)]
        public bool? CanBeUploaded { get; set; }

        /// <summary>
        /// Filter records by create date
        /// </summary>
        [DataMember]
        public DateTimeOffsetV1Filter CreateDate { get; set; }

        /// <summary>
        /// Filter records by last update date
        /// </summary>
        [DataMember]
        public DateTimeOffsetV1Filter LastUpdateDate { get; set; }
    }
}
