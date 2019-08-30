﻿using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.DataSources.ListDataSource
{
    /// <summary>
    /// List data source response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListDataSourceV1Response : BaseResponse
    {
        /// <summary>
        /// List of data sources
        /// </summary>
        [DataMember]
        public IEnumerable<ListDataSourceV1ResponseDataSource> DataSources { get; set; }
            = Enumerable.Empty<ListDataSourceV1ResponseDataSource>();

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
