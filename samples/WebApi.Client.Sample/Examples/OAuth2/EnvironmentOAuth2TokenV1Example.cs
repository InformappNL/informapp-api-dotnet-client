using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.CredentialsProviders;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.OAuth2;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.OAuth2.EnvironmentOAuth2Token;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.OAuth2
{
    internal class EnvironmentOAuth2TokenV1Example : IExample
    {
        private readonly IApiClient<EnvironmentOAuth2TokenV1Request, EnvironmentOAuth2TokenV1Response> _client;

        private readonly ICredentialsProvider _provider;

        public EnvironmentOAuth2TokenV1Example(
            IApiClient<EnvironmentOAuth2TokenV1Request, EnvironmentOAuth2TokenV1Response> client,
            ICredentialsProvider provider)
        {
            Argument.NotNull(client, nameof(client));
            Argument.NotNull(provider, nameof(provider));

            _client = client;

            _provider = provider;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            string username = _provider.GetUserName();
            string password = _provider.GetPassword();

            var request = ApiRequest.Create(new EnvironmentOAuth2TokenV1Request
            {
                GrantType = OAuth2V1Constants.GrantTypes.Password,
                UserName = username,
                Environment = "World",
                Password = password,
            });

            var response = await _client
                .Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
