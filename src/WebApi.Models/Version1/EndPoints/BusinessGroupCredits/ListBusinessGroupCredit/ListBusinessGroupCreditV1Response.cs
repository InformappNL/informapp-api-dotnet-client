using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.BusinessGroupCredits.ListBusinessGroupCredit
{
    /// <summary>
    /// List business group credit response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListBusinessGroupCreditV1Response : BaseResponse
    {
        /// <summary>
        /// List of business group credits
        /// </summary>
        [DataMember]
        public IReadOnlyList<ListBusinessGroupCreditV1ResponseBusinessGroupCredit> BusinessGroupCredits { get; set; }
            = Array.Empty<ListBusinessGroupCreditV1ResponseBusinessGroupCredit>();

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
