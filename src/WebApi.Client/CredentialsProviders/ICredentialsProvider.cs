
namespace Informapp.InformSystem.WebApi.Client.CredentialsProviders
{
    /// <summary>
    /// Interface to provide credentials for the api
    /// </summary>
    public interface ICredentialsProvider
    {
        /// <summary>
        /// Get the username
        /// </summary>
        /// <returns>The username</returns>
        string GetUserName();

        /// <summary>
        /// Get the password
        /// </summary>
        /// <returns>The password</returns>
        string GetPassword();
    }
}
