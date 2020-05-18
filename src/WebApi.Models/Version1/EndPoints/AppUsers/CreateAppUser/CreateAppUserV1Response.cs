using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppUsers.CreateAppUser
{
    /// <summary>
    /// Create app user response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class CreateAppUserV1Response : BaseResponse
    {
        /// <summary>
        /// App user Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "B123A61D-27CC-469B-92A4-4248B583D641")]
        [Required]
        public Guid? AppUserId { get; set; }

        /// <summary>
        /// Location of created app user
        /// </summary>
        [DataMember]
        [DataType(DataType.Url)]
        [ExampleString(ExampleStringKind.AbsoluteUri, "https://localhost/api/v1/appusers/B123A61D-27CC-469B-92A4-4248B583D641")]
        [Required]
        public Uri Location { get; set; }
    }
}
