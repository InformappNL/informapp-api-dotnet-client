using Informapp.InformSystem.WebApi.Models.Sorting;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationEmails.ListFormRegistrationEmail
{
    /// <summary>
    /// Sort form registration emails
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [SortEnum]
    public enum ListFormRegistrationEmailV1Sort
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
        ///  Sort by registration date descending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Desc)]
        [SortName(nameof(RegistrationDate))]
        RegistrationDateDesc = -RegistrationDate,

        /// <summary>
        /// Sort by credit count ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Asc)]
        [SortName(nameof(CreditCount))]
        CreditCount = 3,

        /// <summary>
        /// Sort by credit count descending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Desc)]
        [SortName(nameof(CreditCount))]
        CreditCountDesc = -CreditCount,
    }
}
