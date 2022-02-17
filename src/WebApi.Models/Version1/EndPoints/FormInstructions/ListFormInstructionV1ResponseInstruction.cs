using ConnectedDevelopment.InformSystem.WebApi.Models.DataAnnotations;
using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormInstructions
{
    /// <summary>
    /// Form instruction
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public partial class ListFormInstructionV1ResponseInstruction
    {
        /// <summary>
        /// Form instruction id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "CDF6A94B-E2CF-4DAF-9902-7D02F406B9DF")]
        [MaxLength(FormInstructionV1Constants.ResponseInstructionIdLength)]
        public Guid? FormInstructionId { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        [DataMember]
        [ExampleValue("Please fill out this report")]
        [MaxLength(FormInstructionV1Constants.ResponseMessageLength)]
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
        [EnumValidation(typeof(FormInstructionV1Status))]
        [ExampleValue(FormInstructionV1Status.Completed)]
        public FormInstructionV1Status? Status { get; set; }

        /// <summary>
        /// App users
        /// </summary>
        [DataMember]
        [ExampleMemberProvider(typeof(ListFormInstructionV1ResponseInstruction), nameof(AppUserIds))]
        public IReadOnlyList<Guid?> AppUserIds { get; set; }
            = Array.Empty<Guid?>();
    }
}
