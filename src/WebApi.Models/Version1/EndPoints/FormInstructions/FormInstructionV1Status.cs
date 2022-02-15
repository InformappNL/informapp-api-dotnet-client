using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormInstructions
{
    /// <summary>
    /// Form instruction status
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public enum FormInstructionV1Status
    {
        /// <summary>
        /// InProgress
        /// </summary>
        [EnumMember]
        InProgress = 0,

        /// <summary>
        /// Completed
        /// </summary>
        [EnumMember]
        Completed = 1,

        /// <summary>
        /// Revoked
        /// </summary>
        [EnumMember]
        Revoked = 2,

        /// <summary>
        /// Declined
        /// </summary>
        [EnumMember]
        Declined = 3,
    }
}
