using Informapp.InformSystem.WebApi.Client.RestSharp.Arguments;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using System.IO;

namespace Informapp.InformSystem.WebApi.Client.RestSharp.Deserializers
{
    /// <summary>
    /// NewtonSoft JSON Implementation of <see cref="IJsonDeserializer"/>
    /// </summary>
    public class NewtonSoftJsonDeserializer : IJsonDeserializer
    {
        private readonly JsonSerializer _serializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewtonSoftJsonDeserializer"/> class.
        /// </summary>
        public NewtonSoftJsonDeserializer()
        {
            _serializer = new JsonSerializer()
            {
                DateParseHandling = DateParseHandling.None,
                NullValueHandling = NullValueHandling.Ignore
            };

            _serializer.Converters.Add(new StringEnumConverter());
        }

        private NewtonSoftJsonDeserializer(
            JsonSerializer serializer)
        {
            _serializer = serializer;
        }

        /// <summary>
        /// Root element
        /// </summary>
        public string RootElement { get; set; }

        /// <summary>
        /// Namespace
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Date format
        /// </summary>
        public string DateFormat { get; set; }

        /// <summary>
        /// Deserialize response
        /// </summary>
        /// <typeparam name="T">Deserialize response into this type</typeparam>
        /// <param name="response">The response instance to deserialize</param>
        /// <returns>The deserialized object</returns>
        public T Deserialize<T>(IRestResponse response)
        {
            Argument.NotNull(response, nameof(response));

            var content = response.Content;

            using (var stringReader = new StringReader(content))
            using (var jsonTextReader = new JsonTextReader(stringReader))
            {
                return _serializer.Deserialize<T>(jsonTextReader);
            }
        }
    }
}
