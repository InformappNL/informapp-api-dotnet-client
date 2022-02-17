using ConnectedDevelopment.InformSystem.WebApi.Models.DataAnnotations;
using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Instructions.ListInstruction
{
    /// <summary>
    /// Form instruction
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public partial class ListInformAppFormInstructionV1ResponseInstruction
    {
        /// <summary>
        /// Instruction id
        /// </summary>
        [DataMember]
        [ExampleValue("5cbf0039a6feee2523549291")]
        [MaxLength(InformAppInstructionV1Constants.ResponseInstructionIdLength)]
        public string InstructionId { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        [DataMember]
        [ExampleValue("Please fill out this report")]
        [MaxLength(InformAppInstructionV1Constants.ResponseMessageLength)]
        public string Message { get; set; }

        /// <summary>
        /// Create date
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? CreateDate { get; set; }

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

        /// <summary>
        /// Status
        /// </summary>
        [DataMember]
        [EnumValidation(typeof(InstructionV1Status))]
        [ExampleValue(InstructionV1Status.Completed)]
        public InstructionV1Status? Status { get; set; }

        /// <summary>
        /// Recipients
        /// </summary>
        [DataMember]
        [ExampleMemberProvider(typeof(ListInformAppFormInstructionV1ResponseInstruction), nameof(Recipients))]
        public IReadOnlyList<string> Recipients { get; set; }
            = Array.Empty<string>();
    }
}
