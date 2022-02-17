
namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.OAuth2
{
    /// <summary>
    /// OAuth constants
    /// </summary>
    public static class OAuth2V1Constants
    {
        /// <summary>
        /// Token route
        /// </summary>
        public const string TokenRoute = "api/v1/oauth2/token";

        /// <summary>
        /// Environment token route
        /// </summary>
        public const string EnvironmentTokenRoute = "api/v1/oauth2/environment/token";

        /// <summary>
        /// Grant types
        /// </summary>
        public static class GrantTypes
        {
            /// <summary>
            /// Password
            /// </summary>
            public const string Password = "password";
        }

        /// <summary>
        /// Minimum length for password
        /// </summary>
        public const int PasswordMinLength = 100;



        /// <summary>
        /// Constants for OAUTH2 parameter names
        /// </summary>
        internal static class Parameters
        {
            /// <summary>
            /// GrandType
            /// </summary>
            public const string GrantType = "grant_type";
            /// <summary>
            /// UserName
            /// </summary>
            public const string UserName = "username";
            /// <summary>
            /// Environment
            /// </summary>
            public const string Environment = "environment";
            /// <summary>
            /// Password
            /// </summary>
            public const string Password = "password";

            /// <summary>
            /// AcessToken
            /// </summary>
            public const string AccessToken = "access_token";
            /// <summary>
            /// TokenType
            /// </summary>
            public const string TokenType = "token_type";
            /// <summary>
            /// ExpiresIn
            /// </summary>
            public const string ExpiresIn = "expires_in";
            /// <summary>
            /// Issued
            /// </summary>
            public const string Issued = ".issued";
            /// <summary>
            /// Expires
            /// </summary>
            public const string Expires = ".expires";

            /// <summary>
            /// InvalidGrant
            /// </summary>
            public const string Error = "error";
            /// <summary>
            /// ErrorDescription
            /// </summary>
            public const string ErrorDescription = "error_description";
            /// <summary>
            /// ErrorUri
            /// </summary>
            public const string ErrorUri = "error_uri";
        }
    }
}
