using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormDataNames
{
    /// <summary>
    /// Select columns
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public enum ListFormDataNameV1Select
    {
        /// <summary>
        /// All
        /// </summary>
        [EnumMember]
        All = 0,

        /// <summary>
        /// ParentFormDataNameId
        /// </summary>
        [EnumMember]
        ParentFormDataNameId = 1,

        /// <summary>
        /// Depth
        /// </summary>
        [EnumMember]
        Depth = 2,

        /// <summary>
        /// IsArray
        /// </summary>
        [EnumMember]
        IsArray = 3,

        /// <summary>
        /// Name
        /// </summary>
        [EnumMember]
        Name = 4,

        /// <summary>
        /// FullName
        /// </summary>
        [EnumMember]
        FullName = 5,
    }
}
