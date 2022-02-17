﻿using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Http;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Methods.DeleteMethod
{
    /// <summary>
    /// Delete method response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class DeleteMethodV1Response : BaseResponse
    {
        /// <summary>
        /// Method
        /// </summary>
        [DataMember]
        [ExampleValue(nameof(HttpMethod.Delete))]
        public string Method { get; set; }
    }
}
