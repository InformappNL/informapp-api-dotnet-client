using ConnectedDevelopment.InformSystem.WebApi.Models.Sorting;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Forms.ListForm
{
    /// <summary>
    /// Sort forms
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [SortEnum]
#pragma warning disable CA1008 // Enums should have zero value
    public enum ListFormV1Sort
#pragma warning restore CA1008 // Enums should have zero value
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
        /// Sort by number ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Asc)]
        [SortName(nameof(Number))]
        Number = 3,

        /// <summary>
        /// Sort by number descending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Desc)]
        [SortName(nameof(Number))]
        NumberDesc = -Number,

        /// <summary>
        /// Sort by create date ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Asc)]
        [SortName(nameof(CreateDate))]
        CreateDate = 4,

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
        LastUpdateDate = 5,

        /// <summary>
        /// Sort by last update date descending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Desc)]
        [SortName(nameof(LastUpdateDate))]
        LastUpdateDateDesc = -LastUpdateDate,
    }
}
