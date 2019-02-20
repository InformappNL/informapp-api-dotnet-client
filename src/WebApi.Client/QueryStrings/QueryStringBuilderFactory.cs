
namespace Informapp.InformSystem.WebApi.Client.QueryStrings
{
    /// <summary>
    /// Factory class to construct <see cref="IQueryStringBuilder"/> instances
    /// </summary>
    public class QueryStringBuilderFactory : IQueryStringBuilderFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryStringBuilderFactory"/> class.
        /// </summary>
        public QueryStringBuilderFactory()
        {

        }

        /// <summary>
        /// Create instance of <see cref="IQueryStringBuilder"/>
        /// </summary>
        /// <returns>The constructed <see cref="IQueryStringBuilder"/> instance</returns>
        public IQueryStringBuilder Create()
        {
            return new QueryStringBuilder();
        }

        /// <summary>
        /// Create instance of <see cref="IQueryStringBuilder"/>
        /// </summary>
        /// <param name="query">The query string to parse.</param>
        /// <returns>The constructed <see cref="IQueryStringBuilder"/> instance</returns>
        public IQueryStringBuilder Create(string query)
        {
            return new QueryStringBuilder(query);
        }
    }
}
