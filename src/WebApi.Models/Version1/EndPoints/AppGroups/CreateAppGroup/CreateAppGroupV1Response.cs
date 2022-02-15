using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppGroups.CreateAppGroup
{
    /// <summary>
    /// Create app group response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class CreateAppGroupV1Response : BaseResponse
    {
        /// <summary>
        /// App group Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "93776CFD-4C0D-40CE-8763-2FDF9D6B07CE")]
        [Required]
        public Guid? AppGroupId { get; set; }

        /// <summary>
        /// Location of created app group
        /// </summary>
        [DataMember]
        [DataType(DataType.Url)]
        [ExampleString(ExampleStringKind.AbsoluteUri, "https://localhost/api/v1/appgroups/93776CFD-4C0D-40CE-8763-2FDF9D6B07CE")]
        [Required]
        public Uri Location { get; set; }
    }
}
