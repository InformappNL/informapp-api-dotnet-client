using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Requests
{
    /// <summary>
    /// DTO class for bearer token
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ", nq}")]
    public class ApiBearerToken
    {
        /// <summary>
        /// Returns true when a token is set, null otherwise
        /// </summary>
        [Required]
        public bool? HasToken => string.IsNullOrEmpty(Token) == false ? true : default(bool?);

        /// <summary>
        /// The bearer token
        /// </summary>
        public string Token { private get; set; }

        /// <summary>
        /// Get the bearer token
        /// </summary>
        /// <returns>The bearer token</returns>
#pragma warning disable CA1024 // Use properties where appropriate
        public string GetToken()
#pragma warning restore CA1024 // Use properties where appropriate
        {
            return Token;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => string.Format(CultureInfo.InvariantCulture, "BearerToken: {0} = {1}",
                    nameof(HasToken), HasToken);
    }
}
