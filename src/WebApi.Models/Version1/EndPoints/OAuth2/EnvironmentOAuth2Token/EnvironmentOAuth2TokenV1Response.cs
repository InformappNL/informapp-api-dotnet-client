using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Requests;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.OAuth2.EnvironmentOAuth2Token
{
    /// <summary>
    /// Environment OAuth token response
    /// </summary>
    [DataContract]
    public class EnvironmentOAuth2TokenV1Response : BaseResponse
    {
        /// <summary>
        /// Access token
        /// </summary>
        [DataMember(Name = OAuth2V1Constants.Parameters.AccessToken)]
        [ExampleValue("79AVuxU7luni4UsbVw2xfRBVp-vfUuL07IKCcm")]
        [Required]
        public string AccessToken { get; set; }

        /// <summary>
        /// Token type
        /// </summary>
        [DataMember(Name = OAuth2V1Constants.Parameters.TokenType)]
        [ExampleValue("bearer")]
        [Required]
        public string TokenType { get; set; }

        /// <summary>
        /// Token lifetime in seconds
        /// </summary>
        [DataMember(Name = OAuth2V1Constants.Parameters.ExpiresIn)]
        [ExampleValue(300L)]
        [Required]
        public long? ExpiresIn { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        [DataMember(Name = OAuth2V1Constants.Parameters.UserName)]
        [ExampleValue("JohnDoe")]
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Date and time the token is issued
        /// </summary>
        [DataMember(Name = OAuth2V1Constants.Parameters.Issued)]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        [Required]
        public DateTimeOffset? Issued { get; set; }

        /// <summary>
        /// Expiry date and time of the token
        /// </summary>
        [DataMember(Name = OAuth2V1Constants.Parameters.Expires)]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        [Required]
        public DateTimeOffset? Expires { get; set; }
    }
}
