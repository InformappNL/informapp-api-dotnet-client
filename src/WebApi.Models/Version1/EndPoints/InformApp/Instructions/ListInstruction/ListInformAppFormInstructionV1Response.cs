﻿using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Instructions.ListInstruction
{
    /// <summary>
    /// List form instruction response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListInformAppFormInstructionV1Response : BaseResponse
    {
        /// <summary>
        /// List of form instructions
        /// </summary>
        [DataMember]
        public IReadOnlyList<ListInformAppFormInstructionV1ResponseInstruction> Instructions { get; set; }
            = Array.Empty<ListInformAppFormInstructionV1ResponseInstruction>();

        /// <summary>
        /// Total number of records matching the request
        /// </summary>
        [DataMember]
        [ExampleValue(Version1PageTotalConstants.Example)]
        [Range(Version1PageTotalConstants.Min, Version1PageTotalConstants.Max)]
        [Required]
        public int? Total { get; set; }
    }
}
