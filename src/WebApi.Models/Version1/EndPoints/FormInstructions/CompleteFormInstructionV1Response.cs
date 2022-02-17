﻿using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormInstructions
{
    /// <summary>
    /// Complete form instruction response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class CompleteFormInstructionV1Response : BaseResponse
    {

    }
}
