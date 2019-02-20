using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppGroupMembers.RemoveAppGroupMember
{
    /// <summary>
    /// Remove app group member response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class RemoveAppGroupMemberV1Response : BaseResponse
    {
        /// <summary>
        /// Removed members
        /// </summary>
        [DataMember]
        [Required]
        public IEnumerable<RemoveAppGroupMemberV1ResponseAppGroupMember> RemovedMembers { get; set; }
    }
}
