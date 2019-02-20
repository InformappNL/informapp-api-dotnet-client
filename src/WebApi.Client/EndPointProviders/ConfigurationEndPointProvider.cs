using System;
using System.Configuration;

namespace Informapp.InformSystem.WebApi.Client.EndPointProviders
{
    /// <summary>
    /// Implementation of <see cref="IEndPointProvider"/> to retrieve endpoint from app settings.
    /// </summary>
    public class ConfigurationEndPointProvider : IEndPointProvider
    {
        private static readonly AppSettingsReader _appSettingsReader = new AppSettingsReader();

        private const string EndPointKey = "InformSystemApi:EndPoint";

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationEndPointProvider"/> class.
        /// </summary>
        public ConfigurationEndPointProvider()
        {

        }

        /// <summary>
        /// Get endpoint
        /// </summary>
        /// <returns>The endpoint</returns>
        public Uri GetEndPoint()
        {
            string configValue = _appSettingsReader.GetValue(EndPointKey, typeof(string)) as string;

            var uri = new Uri(configValue, UriKind.Absolute);

            return uri;
        }
    }
}
