﻿using Informapp.InformSystem.WebApi.Models.Sorting;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.DataSources.ListDataSource
{
    /// <summary>
    /// Sort data sources
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [SortEnum]
    public enum ListDataSourceV1Sort
    {
        /// <summary>
        /// Sort by name ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Asc)]
        [SortName(nameof(Name))]
        Name = 1,

        /// <summary>
        /// Sort by name descending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Desc)]
        [SortName(nameof(Name))]
        NameDesc = -Name,

        /// <summary>
        /// Sort by description ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Asc)]
        [SortName(nameof(Description))]
        Description = 2,

        /// <summary>
        /// Sort by description descending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Desc)]
        [SortName(nameof(Description))]
        DescriptionDesc = -Description,

        /// <summary>
        /// Sort by create date ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Asc)]
        [SortName(nameof(CreateDate))]
        CreateDate = 3,

        /// <summary>
        /// Sort by create date descending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Desc)]
        [SortName(nameof(CreateDate))]
        CreateDateDesc = -CreateDate,

        /// <summary>
        /// Sort by last update date ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Asc)]
        [SortName(nameof(LastUpdateDate))]
        LastUpdateDate = 4,

        /// <summary>
        /// Sort by last update date descending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Desc)]
        [SortName(nameof(LastUpdateDate))]
        LastUpdateDateDesc = -LastUpdateDate
    }
}