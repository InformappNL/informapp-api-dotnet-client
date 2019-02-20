using System.Configuration;

namespace Informapp.InformSystem.WebApi.Client.CredentialsProviders
{
    /// <summary>
    /// Implementation of <see cref="ICredentialsProvider"/> to retrieve credentials from app settings.
    /// </summary>
    public class ConfigurationCredentialsProvider : ICredentialsProvider
    {
        private static readonly AppSettingsReader _appSettingsReader = new AppSettingsReader();

        private const string UserNameKey = "InformSystemApi:UserName";
        private const string PasswordKey = "InformSystemApi:Password";

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationCredentialsProvider"/> class.
        /// </summary>
        public ConfigurationCredentialsProvider()
        {

        }

        /// <summary>
        /// Get the username
        /// </summary>
        /// <returns>The username</returns>
        public string GetUserName()
        {
            string username = _appSettingsReader.GetValue(UserNameKey, typeof(string)) as string;

            return username;
        }

        /// <summary>
        /// Get the password
        /// </summary>
        /// <returns>The password</returns>
        public string GetPassword()
        {
            string password = _appSettingsReader.GetValue(PasswordKey, typeof(string)) as string;

            return password;
        }
    }
}
