using ConnectedDevelopment.InformSystem.WebApi.Models.Sorting;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationEmails.ListFormRegistrationEmail
{
    /// <summary>
    /// Sort form registration emails
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [SortEnum]
#pragma warning disable CA1008 // Enums should have zero value
    public enum ListFormRegistrationEmailV1Sort
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
        ///  Sort by registration date descending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Desc)]
        [SortName(nameof(RegistrationDate))]
        RegistrationDateDesc = -RegistrationDate,
    }
}
