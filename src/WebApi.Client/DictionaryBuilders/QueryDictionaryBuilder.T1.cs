using ConnectedDevelopment.InformSystem.WebApi.Models.Http;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.DictionaryBuilders
{
    /// <summary>
    /// Build a dictionary of query string values from an object
    /// </summary>
    /// <typeparam name="T">The model type</typeparam>
    public class QueryDictionaryBuilder<T> : DictionaryBuilder<T, QueryParameterAttribute>,
        IQueryDictionaryBuilder<T>

        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryDictionaryBuilder{T}"/> class.
        /// </summary>
        public QueryDictionaryBuilder()
        {

        }
    }
}
