using Informapp.InformSystem.WebApi.Models.Sorting;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationData.ListFormRegistrationData
{
    /// <summary>
    /// Sort form registration data
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [SortEnum]
    public enum ListFormRegistrationDataV1Sort
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
    }
}
