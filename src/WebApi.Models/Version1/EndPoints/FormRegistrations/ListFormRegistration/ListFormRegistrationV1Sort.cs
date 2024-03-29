﻿using ConnectedDevelopment.InformSystem.WebApi.Models.Sorting;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrations.ListFormRegistration
{
    /// <summary>
    /// Sort form registrations
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [SortEnum]
#pragma warning disable CA1008 // Enums should have zero value
    public enum ListFormRegistrationV1Sort
#pragma warning restore CA1008 // Enums should have zero value
    {
        /// <summary>
        /// Sort by serial number ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Asc)]
        [SortName(nameof(SerialNumber))]
        SerialNumber = 1,

        /// <summary>
        /// Sort by serial number descending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Desc)]
        [SortName(nameof(SerialNumber))]
        SerialNumberDesc = -SerialNumber,

        /// <summary>
        /// Sort by registration date ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Asc)]
        [SortName(nameof(RegistrationDate))]
        RegistrationDate = 2,

        /// <summary>
        /// Sort by registration date descending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Desc)]
        [SortName(nameof(RegistrationDate))]
        RegistrationDateDesc = -RegistrationDate,

        /// <summary>
        /// Sort by sent by user ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Asc)]
        [SortName(nameof(SentByUser))]
        SentByUser = 4,

        /// <summary>
        /// Sort by sent by user descending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Desc)]
        [SortName(nameof(SentByUser))]
        SentByUserDesc = -SentByUser,

        /// <summary>
        /// Sort by create date ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Asc)]
        [SortName(nameof(CreateDate))]
        CreateDate = 5,

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
        LastUpdateDate = 6,

        /// <summary>
        /// Sort by last update date descending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Desc)]
        [SortName(nameof(LastUpdateDate))]
        LastUpdateDateDesc = -LastUpdateDate,
    }
}
