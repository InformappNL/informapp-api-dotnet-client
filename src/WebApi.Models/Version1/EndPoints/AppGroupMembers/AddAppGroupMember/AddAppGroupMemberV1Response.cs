using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppGroupMembers.AddAppGroupMember
{
    /// <summary>
    /// Add app group member response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class AddAppGroupMemberV1Response : BaseResponse
    {
        /// <summary>
        /// Added members
        /// </summary>
        [DataMember]
        [Required]
        public IReadOnlyList<AddAppGroupMemberV1ResponseAppGroupMember> AddedMembers { get; set; }
    }
}
