﻿using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.OAuth2.OAuth2Token
{
    /// <summary>
    /// OAuth token bad request model
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class OAuth2TokenV1ResponseBadRequest
    {
        /// <summary>
        /// Error
        /// </summary>
        [DataMember(Name = OAuth2V1Constants.Parameters.Error)]
        [ExampleValue("invalid_grant")]
        public string Error { get; set; }

        /// <summary>
        /// Error description
        /// </summary>
        [DataMember(Name = OAuth2V1Constants.Parameters.ErrorDescription)]
        [ExampleValue("The username or password is incorrect.")]
        public string ErrorDescription { get; set; }

        /// <summary>
        /// Error uri
        /// </summary>
        [DataMember(Name = OAuth2V1Constants.Parameters.ErrorUri)]
        [ExampleLocalizedUri("/help")]
        public Uri ErrorUri { get; set; }
    }
}
