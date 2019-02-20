using Informapp.InformSystem.WebApi.Client.Arguments;
using Informapp.InformSystem.WebApi.Client.Converters;
using Informapp.InformSystem.WebApi.Client.Requests;
using System;

namespace Informapp.InformSystem.WebApi.Client.BearerTokenProviders
{
    /// <summary>
    /// Converter class to convert <see cref="ApiRequest"/> to <see cref="BearerTokenKey"/>
    /// </summary>
    public class ApiRequestToBearerTokenKeyConverter : IConverter<ApiRequest, BearerTokenKey>
    {
        /// <summary>
        /// Convert value
        /// </summary>
        /// <param name="source">The source</param>
        /// <returns>They bearer token key</returns>
        public ConvertResult<BearerTokenKey> Convert(ApiRequest source)
        {
            Argument.NotNull(source, nameof(source));

            BearerTokenKey key;

            switch (source.Credentials.Kind)
            {
                case CredentialsKind.Default:
                    key = new BearerTokenKey(
                        source.Context.EndPoint,
                        source.Credentials.Username);
                    break;
                case CredentialsKind.Environment:
                    key = new BearerTokenKey(
                        source.Context.EndPoint,
                        source.Credentials.Username,
                        source.Credentials.Environment);
                    break;
                case CredentialsKind.Impersonate:
                    key = new BearerTokenKey(
                        source.Context.EndPoint,
                        source.Credentials.Username,
                        source.Credentials.Environment,
                        source.Credentials.ImpersonateUserId);
                    break;
                default:
                    throw new InvalidOperationException("Unsupported value: " + source.Credentials.Kind);
            }

            var convertResult = ConvertResult.FromReference(key);

            return convertResult;
        }
    }
}
