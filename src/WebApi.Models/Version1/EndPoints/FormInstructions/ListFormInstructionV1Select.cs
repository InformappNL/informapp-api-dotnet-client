using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormInstructions
{
    /// <summary>
    /// Select columns
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public enum ListFormInstructionV1Select
    {
        /// <summary>
        /// All
        /// </summary>
        [EnumMember]
        All = 0,

        /// <summary>
        /// Create date
        /// </summary>
        [EnumMember]
        CreateDate = 1,

        /// <summary>
        /// Publish date
        /// </summary>
        [EnumMember]
        PublishDate = 2,

        /// <summary>
        /// Information date
        /// </summary>
        [EnumMember]
        InformationDate = 3,

        /// <summary>
        /// Status
        /// </summary>
        [EnumMember]
        Status = 4,

        /// <summary>
        /// Status
        /// </summary>
        [EnumMember]
        AppUserGuids = 5,
    }
}
