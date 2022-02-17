using ConnectedDevelopment.InformSystem.WebApi.Models.Sorting;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Instructions.ListInstruction
{
    /// <summary>
    /// Sort form instructions
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [SortEnum]
#pragma warning disable CA1008 // Enums should have zero value
    public enum ListInformAppFormInstructionV1Sort
#pragma warning restore CA1008 // Enums should have zero value
    {
        /// <summary>
        /// Sort create date ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Asc)]
        [SortName(nameof(CreateDate))]
        CreateDate = 1,

        /// <summary>
        /// Sort create date ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Desc)]
        [SortName(nameof(CreateDate))]
        CreateDateDesc = -CreateDate,

        /// <summary>
        /// Sort publish date ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Asc)]
        [SortName(nameof(PublishDate))]
        PublishDate = 2,

        /// <summary>
        /// Sort publish date ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Desc)]
        [SortName(nameof(PublishDate))]
        PublishDateDesc = -PublishDate,

        /// <summary>
        /// Sort information date ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Asc)]
        [SortName(nameof(InformationDate))]
        InformationDate = 3,

        /// <summary>
        /// Sort information date ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Desc)]
        [SortName(nameof(InformationDate))]
        InformationDateDesc = -InformationDate,

        /// <summary>
        /// Sort status ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Asc)]
        [SortName(nameof(Status))]
        Status = 4,

        /// <summary>
        /// Sort status ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Desc)]
        [SortName(nameof(Status))]
        StatusDesc = -Status,

        /// <summary>
        /// Sort message ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Asc)]
        [SortName(nameof(Message))]
        Message = 5,

        /// <summary>
        /// Sort message ascending
        /// </summary>
        [EnumMember]
        [SortDirection(SortDirection.Desc)]
        [SortName(nameof(Message))]
        MessageDesc = -Message,
    }
}
