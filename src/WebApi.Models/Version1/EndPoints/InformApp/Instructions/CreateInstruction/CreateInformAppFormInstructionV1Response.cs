using Informapp.InformSystem.WebApi.Models.DataAnnotations;
using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Instructions.CreateInstruction
{
    /// <summary>
    /// Create form instruction response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public partial class CreateInformAppFormInstructionV1Response : BaseResponse
    {
        /// <summary>
        /// Instruction id
        /// </summary>
        [DataMember]
        [ExampleValue("5cbf0039a6feee2523549291")]
        [MaxLength(InformAppInstructionV1Constants.ResponseInstructionIdLength)]
        [Required]
        public string InstructionId { get; set; }

        /// <summary>
        /// Recipients
        /// </summary>
        [DataMember]
        [ExampleMemberProvider(typeof(CreateInformAppFormInstructionV1Response), nameof(Recipients))]
        public IReadOnlyList<string> Recipients { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        [DataMember]
        [ExampleValue("Please complete the order")]
        public string Message { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [DataMember]
        [EnumValidation(typeof(InstructionV1Status))]
        [ExampleValue(InstructionV1Status.InProgress)]
        public InstructionV1Status? Status { get; set; }

        /// <summary>
        /// Creation date
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? CreationDate { get; set; }

        /// <summary>
        /// Publish date
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? PublishDate { get; set; }

        /// <summary>
        /// Information date
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? InformationDate { get; set; }
    }
}
