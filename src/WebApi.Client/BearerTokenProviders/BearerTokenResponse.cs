using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using System;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.BearerTokenProviders
{
    /// <summary>
    /// Bearer token model class
    /// </summary>
    public class BearerTokenResponse
    {
        /// <summary>
        /// Response
        /// </summary>
        public ApiResponse Response { get; set; }

        /// <summary>
        /// The access token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Token type
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// Token lifetime in seconds
        /// </summary>
        public long? ExpiresIn { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Date and time the token is issued
        /// </summary>
        public DateTimeOffset? Issued { get; set; }

        /// <summary>
        /// Expiry date and time of the token
        /// </summary>
        public DateTimeOffset? Expires { get; set; }
    }
}
