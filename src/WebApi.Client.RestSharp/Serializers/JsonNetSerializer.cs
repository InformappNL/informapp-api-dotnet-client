using Informapp.InformSystem.WebApi.Client.RestSharp.Arguments;
using Informapp.InformSystem.WebApi.Models.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using RestSharp.Serialization;

namespace Informapp.InformSystem.WebApi.Client.RestSharp.Serializers
{
    /// <summary>
    /// Newtonsoft.Json implementation of <see cref="IRestSerializer"/>
    /// </summary>
    public class JsonNetSerializer : IRestSerializer
    {
        private readonly JsonSerializerSettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonNetSerializer"/> class.
        /// </summary>
        public JsonNetSerializer()
        {
            var settings = new JsonSerializerSettings
            {
                DateParseHandling = DateParseHandling.None,
                NullValueHandling = NullValueHandling.Ignore,
            };

            settings.Converters.Add(new StringEnumConverter());

            _settings = settings;
        }

        /// <summary>
        /// Serialize object
        /// </summary>
        /// <param name="obj">The object to serialize</param>
        /// <returns>The serialized string</returns>
        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, _settings);
        }

        /// <summary>
        /// Serialize parameter
        /// </summary>
        /// <param name="parameter">The parameter to serialize</param>
        /// <returns>The serialized string</returns>
#pragma warning disable CS0618 // Type or member is obsolete - defined by interface IRestSerializer
        public string Serialize(Parameter parameter)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            Argument.NotNull(parameter, nameof(parameter));

            return JsonConvert.SerializeObject(parameter.Value, _settings);
        }

        /// <summary>
        /// Deserialize response
        /// </summary>
        /// <typeparam name="T">The type of model</typeparam>
        /// <param name="response">The response</param>
        /// <returns>The deserialized model</returns>
        public T Deserialize<T>(IRestResponse response)
        {
            Argument.NotNull(response, nameof(response));

            return JsonConvert.DeserializeObject<T>(response.Content, _settings);
        }

        /// <summary>
        /// Supported content types
        /// </summary>
        public string[] SupportedContentTypes => new[] { ContentTypeConstants.Application.Json };

        /// <summary>
        /// Content type
        /// </summary>
        public string ContentType { get; set; } = ContentTypeConstants.Application.Json;

        /// <summary>
        /// Data format
        /// </summary>
        public DataFormat DataFormat { get; } = DataFormat.Json;
    }
}
