using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppUsers.ListAppUser
{
    /// <summary>
    /// List app user response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListAppUserV1Response : BaseResponse
    {
        /// <summary>
        /// List of app users
        /// </summary>
        [DataMember]
        public IReadOnlyList<ListAppUserV1ResponseAppUser> AppUsers { get; set; }
            = Array.Empty<ListAppUserV1ResponseAppUser>();

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
