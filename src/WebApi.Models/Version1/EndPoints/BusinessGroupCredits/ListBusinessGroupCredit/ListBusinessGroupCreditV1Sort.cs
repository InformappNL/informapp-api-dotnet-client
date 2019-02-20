using Informapp.InformSystem.WebApi.Models.Sorting;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.BusinessGroupCredits.ListBusinessGroupCredit
{
    /// <summary>
    /// Sort business group credits
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [SortEnum]
    public enum ListBusinessGroupCreditV1Sort
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
        /// Sort by total registration count ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Asc)]
        [SortName(nameof(TotalRegistrationCount))]
        TotalRegistrationCount = 2,

        /// <summary>
        /// Sort by total registration count descending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Desc)]
        [SortName(nameof(TotalRegistrationCount))]
        TotalRegistrationCountDesc = -TotalRegistrationCount,

        /// <summary>
        /// Sort by total credits of non empty bundles ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Asc)]
        [SortName(nameof(TotalCreditsOfNonEmptyBundles))]
        TotalCreditsOfNonEmptyBundles = 3,

        /// <summary>
        /// Sort by total credits of non empty bundles descending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Desc)]
        [SortName(nameof(TotalCreditsOfNonEmptyBundles))]
        TotalCreditsOfNonEmptyBundlesDesc = -TotalCreditsOfNonEmptyBundles,

        /// <summary>
        /// Sort by total available credits descending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Asc)]
        [SortName(nameof(TotalAvailableCredits))]
        TotalAvailableCredits = 4,

        /// <summary>
        /// Sort by total available credits descending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Desc)]
        [SortName(nameof(TotalAvailableCredits))]
        TotalAvailableCreditsDesc = -TotalAvailableCredits,

        /// <summary>
        /// Sort by total credits descending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Asc)]
        [SortName(nameof(TotalCredits))]
        TotalCredits = 5,

        /// <summary>
        /// Sort by total credits descending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Desc)]
        [SortName(nameof(TotalCredits))]
        TotalCreditsDesc = -TotalCredits,

        /// <summary>
        /// Sort by create date ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Asc)]
        [SortName(nameof(CreateDate))]
        CreateDate = 6,

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
        LastUpdateDate = 7,

        /// <summary>
        /// Sort by last update date descending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Desc)]
        [SortName(nameof(LastUpdateDate))]
        LastUpdateDateDesc = -LastUpdateDate
    }
}
