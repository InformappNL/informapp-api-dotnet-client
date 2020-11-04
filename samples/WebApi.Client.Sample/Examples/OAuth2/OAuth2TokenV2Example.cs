using Informapp.InformSystem.WebApi.Client.Configuration;
using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version2.EndPoints.OAuth2;
using Informapp.InformSystem.WebApi.Models.Version2.EndPoints.OAuth2.OAuth2Token;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.OAuth2
{
    internal class OAuth2TokenV2Example : IExample
    {
        private readonly IApiClient<OAuth2TokenV2Request, OAuth2TokenV2Response> _client;

        private readonly IOptions<ApiConfiguration> _options;

        public OAuth2TokenV2Example(
            IApiClient<OAuth2TokenV2Request, OAuth2TokenV2Response> client,
            IOptions<ApiConfiguration> options)
        {
            Argument.NotNull(client, nameof(client));
            Argument.NotNull(options, nameof(options));

            _client = client;

            _options = options;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            string username = _options.Value.UserName;
            string password = _options.Value.Password;

            var request = new OAuth2TokenV2Request
            {
                GrantType = OAuth2V2Constants.GrantTypes.Password,
                UserName = username,
                Password = password,
            };

            var response = await _client
                .Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
