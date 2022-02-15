using Informapp.InformSystem.WebApi.Models.Sorting;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormInstructions
{
    /// <summary>
    /// Sort form instructions
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [SortEnum]
#pragma warning disable CA1008 // Enums should have zero value
    public enum ListFormInstructionV1Sort
#pragma warning restore CA1008 // Enums should have zero value
    {
        /// <summary>
        /// Sort by create date ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Asc)]
        [SortName(nameof(CreateDate))]
        CreateDate = 1,

        /// <summary>
        /// Sort by create date ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Desc)]
        [SortName(nameof(CreateDate))]
        CreateDateDesc = -CreateDate,

        /// <summary>
        /// Sort by publish date ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Asc)]
        [SortName(nameof(PublishDate))]
        PublishDate = 2,

        /// <summary>
        /// Sort by publish date ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Desc)]
        [SortName(nameof(PublishDate))]
        PublishDateDesc = -PublishDate,

        /// <summary>
        /// Sort by information date ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Asc)]
        [SortName(nameof(InformationDate))]
        InformationDate = 3,

        /// <summary>
        /// Sort by information date ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Desc)]
        [SortName(nameof(InformationDate))]
        InformationDateDesc = -InformationDate,

        /// <summary>
        /// Sort by status ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Asc)]
        [SortName(nameof(Status))]
        Status = 4,

        /// <summary>
        /// Sort by status ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Desc)]
        [SortName(nameof(Status))]
        StatusDesc = -Status,
    }
}
