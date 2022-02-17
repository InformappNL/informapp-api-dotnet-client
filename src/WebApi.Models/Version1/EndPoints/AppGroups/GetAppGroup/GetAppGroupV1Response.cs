using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.AppGroups.GetAppGroup
{
    /// <summary>
    /// App group response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class GetAppGroupV1Response : BaseResponse
    {
        /// <summary>
        /// App group Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "2A765D6E-68C1-4908-9C52-4D0FFFB18245")]
        [Required]
        public Guid? AppGroupId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [DataMember]
        [ExampleValue("Inspectors")]
        [MaxLength(AppGroupV1Constants.ResponseNameLength)]
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [DataMember]
        [ExampleValue("Inspectors")]
        [MaxLength(AppGroupV1Constants.ResponseDescriptionLength)]
        public string Description { get; set; }

        /// <summary>
        /// Business group Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "8F74638B-36BC-4F0B-815C-BC3A0B5651D1")]
        public Guid? BusinessGroupId { get; set; }

        /// <summary>
        /// Create date
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? CreateDate { get; set; }

        /// <summary>
        /// Last update date
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? LastUpdateDate { get; set; }
    }
}
