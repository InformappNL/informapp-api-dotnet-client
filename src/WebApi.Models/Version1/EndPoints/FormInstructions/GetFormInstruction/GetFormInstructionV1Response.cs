using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Form.Instructions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormInstructions.GetFormInstruction
{
    /// <summary>
    /// Get Form Instruction response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public partial class GetFormInstructionV1Response : BaseResponse
    {
        /// <summary>
        /// Form Instruction Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "EE1F7957-3402-45DC-93E4-6689B7E26776")]
        [Required]
        public Guid? FormInstructionId { get; set; }

        /// <summary>
        /// Form Instruction Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "EE1F7957-3402-45DC-93E4-6689B7E26776")]
        [Required]
        public Guid? FormId { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        [DataMember]
        [ExampleValue("Please fill out this report")]
        [MaxLength(FormInstructionV1Constants.ResponseMessageLength)]
        public string Message { get; set; }

        /// <summary>
        /// Form data
        /// </summary>
        [DataMember]
        [ExampleValue("Form JSON")]
        public string FormData { get; set; }

        /// <summary>
        /// Create date
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? CreateDate { get; set; }

        /// <summary>
        /// Information date
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? InformationDate { get; set; }

        /// <summary>
        /// Publish date
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? PublishDate { get; set; }

        /// <summary>
        /// Form Instruction Users
        /// </summary>
        [DataMember]
        [ExampleMemberProvider(typeof(GetFormInstructionV1Response), nameof(AppUserIds))]
        public IReadOnlyList<Guid?> AppUserIds { get; set; }
            = Array.Empty<Guid?>();
    }
}
