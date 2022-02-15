﻿using Informapp.InformSystem.WebApi.Models.DataAnnotations;
using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Instructions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Form.Instructions.ListInstruction
{
    /// <summary>
    /// List form instruction
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public partial class ListFormInstructionV1ResponseInstruction
    {
        /// <summary>
        /// Form instruction id
        /// </summary>
        [DataMember]
        [ExampleValue("5cbf0039a6feee2523549291")]
        [MaxLength(FormInstructionV1Constants.ResponseInstructionIdLength)]
        public string FormInstructionId { get; set; }

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
        /// Recipients
        /// </summary>
        [DataMember]
        [ExampleMemberProvider(typeof(ListFormInstructionV1ResponseInstruction), nameof(AppUserIds))]
        public IReadOnlyList<Guid?> AppUserIds { get; set; }
            = Array.Empty<Guid?>();
    }
}
