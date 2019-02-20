using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.BusinessGroups.ListBusinessGroup
{
    /// <summary>
    /// List business group response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListBusinessGroupV1Response : BaseResponse
    {
        /// <summary>
        /// List of business groups
        /// </summary>
        [DataMember]
        public IEnumerable<ListBusinessGroupV1ResponseBusinessGroup> BusinessGroups { get; set; }
            = Enumerable.Empty<ListBusinessGroupV1ResponseBusinessGroup>();

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
