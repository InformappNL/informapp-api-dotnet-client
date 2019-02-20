using Informapp.InformSystem.WebApi.Client.Arguments;
using Informapp.InformSystem.WebApi.Client.DictionaryBuilders;
using Informapp.InformSystem.WebApi.Client.QueryStrings;
using System;

namespace Informapp.InformSystem.WebApi.Client.QueryStringProviders
{
    /// <summary>
    /// Retrieve query string for a class
    /// </summary>
    /// <typeparam name="T">Type to get query string from</typeparam>
    public class QueryProvider<T> : IQueryProvider<T>
        where T : class
    {
        private readonly IQueryDictionaryBuilder<T> _queryDictionaryBuilder;

        private readonly IQueryStringBuilderFactory _queryStringBuilderFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryProvider{T}"/> class.
        /// </summary>
        public QueryProvider(
            IQueryDictionaryBuilder<T> queryDictionaryBuilder,
            IQueryStringBuilderFactory queryStringBuilderFactory)
        {
            Argument.NotNull(queryDictionaryBuilder, nameof(queryDictionaryBuilder));
            Argument.NotNull(queryStringBuilderFactory, nameof(queryStringBuilderFactory));

            _queryDictionaryBuilder = queryDictionaryBuilder;

            _queryStringBuilderFactory = queryStringBuilderFactory;
        }

        /// <summary>
        /// Get query string for the given instance
        /// </summary>
        /// <param name="instance">Make query string from this object</param>
        /// <returns>The query string</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is null</exception>
        public string GetQueryString(T instance)
        {
            Argument.NotNull(instance, nameof(instance));

            var dictionary = _queryDictionaryBuilder.GetDictionary(instance);

            string query = _queryStringBuilderFactory.Create()
                .Add(dictionary)
                .ToString();

            return query;
        }
    }
}
