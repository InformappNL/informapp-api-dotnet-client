using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version2.Constants;
using System;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version2.EndPoints.OAuth2.OAuth2Token
{
    /// <summary>
    /// OAuth token bad request model
    /// </summary>
    [DataContract(Namespace = Version2Constants.Namespace)]
    public class OAuth2TokenV2ResponseBadRequest
    {
        /// <summary>
        /// Error
        /// </summary>
        [DataMember(Name = OAuth2V2Constants.Parameters.Error)]
        [ExampleValue("invalid_grant")]
        public string Error { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [DataMember(Name = OAuth2V2Constants.Parameters.ErrorDescription)]
        [ExampleValue("The username or password is incorrect.")]
        public string ErrorDescription { get; set; }

        /// <summary>
        /// Error uri
        /// </summary>
        [DataMember(Name = OAuth2V2Constants.Parameters.ErrorUri)]
        [ExampleLocalizedUri("/help")]
        public Uri ErrorUri { get; set; }
    }
}
