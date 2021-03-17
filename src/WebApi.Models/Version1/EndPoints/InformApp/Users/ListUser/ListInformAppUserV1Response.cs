using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Users.ListUser
{
    /// <summary>
    /// List user response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListInformAppUserV1Response : BaseResponse
    {
        /// <summary>
        /// List of users
        /// </summary>
        [DataMember]
        public IReadOnlyList<ListInformAppUserV1ResponseUser> Users { get; set; }
            = Array.Empty<ListInformAppUserV1ResponseUser>();

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
