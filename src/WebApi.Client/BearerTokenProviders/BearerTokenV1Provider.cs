using Informapp.InformSystem.WebApi.Client.Arguments;
using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.OAuth2;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.OAuth2.OAuth2Token;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.BearerTokenProviders
{
    /// <summary>
    /// Provider class for bearer tokens
    /// </summary>
    public class BearerTokenV1Provider : IBearerTokenProvider<OAuth2TokenV1Request>
    {
        private readonly Lazy<IApiClient<OAuth2TokenV1Request, OAuth2TokenV1Response>> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="BearerTokenV1Provider"/> class.
        /// </summary>
        /// <param name="client">The client to use to obtain tokens</param>
        public BearerTokenV1Provider(
            Lazy<IApiClient<OAuth2TokenV1Request, OAuth2TokenV1Response>> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        /// <summary>
        /// Get bearer token
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The token response</returns>
        public async Task<BearerTokenResponse> GetToken(ApiRequest request, CancellationToken cancellationToken)
        {
            Argument.NotNull(request, nameof(request));

            var tokenRequest = ApiRequest.Create(new OAuth2TokenV1Request
            {
                GrantType = OAuth2V1Constants.GrantTypes.Password,
                UserName = request.Credentials.Username,
                Password = request.Credentials.GetPassword(),
            });

            var apiResponse = await _client.Value.Execute(tokenRequest, cancellationToken);

            var response = new BearerTokenResponse
            {
                Response = apiResponse
            };

            if (apiResponse.IsSuccessful == true)
            {
                response.AccessToken = apiResponse.Model.AccessToken;
                response.TokenType = apiResponse.Model.TokenType;
                response.ExpiresIn = apiResponse.Model.ExpiresIn;
                response.Username = apiResponse.Model.Username;
                response.Issued = apiResponse.Model.Issued;
                response.Expires = apiResponse.Model.Expires;
            }

            return response;
        }
    }
}
