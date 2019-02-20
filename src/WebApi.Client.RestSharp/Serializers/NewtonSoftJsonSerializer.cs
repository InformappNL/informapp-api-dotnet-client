using Informapp.InformSystem.WebApi.Client.RestSharp.Arguments;
using Informapp.InformSystem.WebApi.Models.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;

namespace Informapp.InformSystem.WebApi.Client.RestSharp.Serializers
{
    /// <summary>
    /// NewtonSoft JSON Implementation of <see cref="IJsonSerializer"/>
    /// </summary>
    public class NewtonSoftJsonSerializer : IJsonSerializer
    {
        private readonly JsonSerializer _serializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewtonSoftJsonSerializer"/> class.
        /// </summary>
        public NewtonSoftJsonSerializer()
        {
            _serializer = new JsonSerializer()
            {
                DateParseHandling = DateParseHandling.None,
                NullValueHandling = NullValueHandling.Ignore,
            };

            _serializer.Converters.Add(new StringEnumConverter());
        }

        private NewtonSoftJsonSerializer(
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
        /// Content type
        /// </summary>
        public string ContentType { get; set; } = ContentTypeConstants.Application.Json;

        /// <summary>
        /// Serialize object
        /// </summary>
        /// <param name="obj">The object to serialize</param>
        /// <returns>The object serialized as JSON string</returns>
        public string Serialize(object obj)
        {
            Argument.NotNull(obj, nameof(obj));

            using (var stringWriter = new StringWriter())
            using (var jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                _serializer.Serialize(jsonTextWriter, obj);

                return stringWriter.ToString();
            }
        }
    }
}
