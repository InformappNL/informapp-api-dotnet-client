using Informapp.InformSystem.WebApi.Client.Arguments;
using Informapp.InformSystem.WebApi.Client.HashCodes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Informapp.InformSystem.WebApi.Client.QueryStrings
{
    /// <summary>
    /// Build a query string
    /// </summary>
    public class QueryStringBuilder : IQueryStringBuilder
    {
        private static readonly JsonSerializer _serializer = GetSerializer();

        private static JsonSerializer GetSerializer()
        {
            var serializer = new JsonSerializer();

            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.DateParseHandling = DateParseHandling.None;

            serializer.ContractResolver = new QueryStringContractResolver();

            return serializer;
        }

        private static readonly IEqualityComparer<string> _comparer = new Comparer();

        private readonly NameValueCollection _collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryStringBuilder"/> class.
        /// </summary>
        public QueryStringBuilder() : this(string.Empty)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryStringBuilder"/> class.
        /// </summary>
        /// <param name="query">The query string to parse.</param>
        public QueryStringBuilder(string query)
        {
            _collection = HttpUtility.ParseQueryString(query ?? string.Empty);
        }

        /// <summary>
        /// Add key and value to the query string
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="value">The value</param>
        /// <returns>The query string builder</returns>
        public IQueryStringBuilder Add(string key, string value)
        {
            Argument.NotNull(key, nameof(key));
            Argument.NotNull(value, nameof(value));

            _collection.Add(key, value);

            return this;
        }

        /// <summary>
        /// Add object to the query string
        /// </summary>
        /// <param name="obj">The object to add to the query string</param>
        /// <returns>The query string builder</returns>
        public IQueryStringBuilder Add(object obj)
        {
            Argument.NotNull(obj, nameof(obj));

            var dictionary = GetDictionary(obj);

            if (dictionary != null)
            {
                foreach (var item in dictionary)
                {
                    _collection.Add(item.Key, item.Value);
                }
            }

            return this;
        }

        /// <summary>
        /// Build dictionary with key and values from an object
        /// </summary>
        /// Source: http://geeklearning.io/serialize-an-object-to-an-url-encoded-string-in-csharp/
        /// <param name="obj"></param>
        /// <returns></returns>
        private IDictionary<string, string> GetDictionary(object obj)
        {
            if (obj == null)
            {
                return null;
            }

            var jToken = obj as JToken;

            if (jToken == null)
            {
                var jObject = JObject.FromObject(obj, _serializer);

                return GetDictionary(jObject);
            }

            if (jToken.HasValues)
            {
                var contentData = new Dictionary<string, string>(_comparer);

                var children = jToken.Children()
                    .ToList();

                foreach (var child in children)
                {
                    var childContent = GetDictionary(child);

                    if (childContent != null)
                    {
                        foreach (var item in childContent)
                        {
                            contentData.Add(item.Key, item.Value);
                        }
                    }
                }

                return contentData;
            }

            var jValue = jToken as JValue;

            if (jValue?.Value == null)
            {
                return null;
            }

            var dictionary = new Dictionary<string, string>(_comparer);

            string value = jValue.Type == JTokenType.Date ?
                jValue.ToString("o", CultureInfo.InvariantCulture) :
                jValue.ToString(CultureInfo.InvariantCulture);

            dictionary.Add(jToken.Path, value);

            return dictionary;
        }

        /// <summary>
        /// Convert the build query string to a <see cref="string"/>
        /// </summary>
        /// <returns>The query string</returns>
        public override string ToString()
        {
            return _collection.ToString();
        }

        private class Comparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y)
            {
                return false;
            }

            public int GetHashCode(string obj)
            {
                if (obj != null)
                {
                    return obj.GetHashCode();
                }

                return HashCodeHelper.DefaultValue;
            }
        }

        private class QueryStringContractResolver : DefaultContractResolver
        {
            protected override JsonContract CreateContract(Type objectType)
            {
                if (objectType == typeof(byte[]))
                {
                    return CreateArrayContract(objectType);
                }

                return base.CreateContract(objectType);
            }
        }
    }
}
