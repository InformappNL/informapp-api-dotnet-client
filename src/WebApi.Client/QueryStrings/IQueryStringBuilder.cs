
namespace Informapp.InformSystem.WebApi.Client.QueryStrings
{
    /// <summary>
    /// Interface for query string builder
    /// </summary>
    public interface IQueryStringBuilder
    {
        /// <summary>
        /// Add key and value to the query string
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="value">The value</param>
        /// <returns>The query string builder</returns>
        IQueryStringBuilder Add(string key, string value);

        /// <summary>
        /// Add object to the query string
        /// </summary>
        /// <param name="obj">The object to add to the query string</param>
        /// <returns>The query string builder</returns>
        IQueryStringBuilder Add(object obj);

        /// <summary>
        /// Convert the build query string to a <see cref="string"/>
        /// </summary>
        /// <returns>The query string</returns>
        string ToString();
    }
}
