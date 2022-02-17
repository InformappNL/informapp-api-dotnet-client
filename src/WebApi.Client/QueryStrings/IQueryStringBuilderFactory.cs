
namespace ConnectedDevelopment.InformSystem.WebApi.Client.QueryStrings
{
    /// <summary>
    /// Interface to construct <see cref="IQueryStringBuilder"/> instances
    /// </summary>
    public interface IQueryStringBuilderFactory
    {
        /// <summary>
        /// Create instance of <see cref="IQueryStringBuilder"/>
        /// </summary>
        /// <returns>The constructed <see cref="IQueryStringBuilder"/> instance</returns>
        IQueryStringBuilder Create();

        /// <summary>
        /// Create instance of <see cref="IQueryStringBuilder"/>
        /// </summary>
        /// <param name="query">The query string to parse.</param>
        /// <returns>The constructed <see cref="IQueryStringBuilder"/> instance</returns>
        IQueryStringBuilder Create(string query);
    }
}
