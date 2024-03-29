﻿using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormInstructions
{
    /// <summary>
    /// Retrieve form instruction response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public partial class RetrieveFormInstructionV1Response : BaseResponse
    {
        /// <summary>
        /// Form Instruction Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "EE1F7957-3402-45DC-93E4-6689B7E26776")]
        [Required]
        public Guid? FormInstructionId { get; set; }

        /// <summary>
        /// Form Id
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
        /// App users
        /// </summary>
        [DataMember]
        [ExampleMemberProvider(typeof(RetrieveFormInstructionV1Response), nameof(AppUserIds))]
        public IReadOnlyList<Guid?> AppUserIds { get; set; }
            = Array.Empty<Guid?>();
    }
}
