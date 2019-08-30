using Informapp.InformSystem.WebApi.Client.CredentialsProviders;
using Informapp.InformSystem.WebApi.Client.DictionaryBuilders;
using Informapp.InformSystem.WebApi.Client.EndPointProviders;
using Informapp.InformSystem.WebApi.Client.PathProviders;
using Informapp.InformSystem.WebApi.Client.QueryStringProviders;
using Informapp.InformSystem.WebApi.Client.QueryStrings;
using Informapp.InformSystem.WebApi.Client.RestSharp.Serializers;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Http;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.OAuth2;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.OAuth2.OAuth2Token;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Values.ListValues;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Values.TestValues;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.Clients
{
    internal class RestSharpExample : IExample
    {
        public RestSharpExample()
        {

        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            var getValuesRequest = new ListValuesV1Request();
            var getValuesResponse = await Run<ListValuesV1Request, ListValuesV1Response>(getValuesRequest, cancellationToken)
                .ConfigureAwait(Await.Default);

            Require.NotNull(getValuesResponse, nameof(getValuesResponse));



            var putValuesRequest = new TestValuesV1Request();
            var putValuesResponse = await Run<TestValuesV1Request, TestValuesV1Response>(putValuesRequest, cancellationToken)
                .ConfigureAwait(Await.Default);

            Require.NotNull(putValuesResponse, nameof(putValuesResponse));
        }

        public async Task<IRestResponse<TResponse>> Run<TRequest, TResponse>(TRequest model, CancellationToken cancellationToken)
            where TRequest : class, IRequest<TResponse>
            where TResponse : class
        {
            var endPointProvider = new ConfigurationEndPointProvider();

            var endPoint = endPointProvider.GetEndPoint();

            var pathProvider = new PathProvider<TRequest>();

            var path = pathProvider.GetPath(model);

            var queryProvider = new QueryProvider<TRequest>(
                new QueryDictionaryBuilder<TRequest>(),
                new QueryStringBuilderFactory());

            var query = queryProvider.GetQueryString(model);

            var resource = path;

            if (string.IsNullOrEmpty(query) == false)
            {
                resource = new Uri(path.ToString() + '?' + query, UriKind.Relative);
            }

            var client = new RestClient(endPoint)
                .UseSerializer(() => new JsonNetSerializer());

            string accessToken = await GetToken(client, cancellationToken)
                .ConfigureAwait(Await.Default);

            client.Authenticator = new JwtAuthenticator(accessToken);

            var request = new RestRequest(resource, Method.GET)
            {
                RequestFormat = DataFormat.Json
            };

            var response = await client
                .ExecuteTaskAsync<TResponse>(request, cancellationToken)
                .ConfigureAwait(Await.Default);

            return response;
        }

        private OAuth2TokenV1Response _token;

        private async Task<string> GetToken(IRestClient client, CancellationToken cancellationToken)
        {
            var now = DateTimeOffset.UtcNow;

            if (_token != null &&
                _token.Expires > now)
            {
                return _token.AccessToken;
            }

            var credentialsProvider = new ConfigurationCredentialsProvider();

            string username = credentialsProvider.GetUserName();
            string password = credentialsProvider.GetPassword();

            var model = new OAuth2TokenV1Request
            {
                GrantType = OAuth2V1Constants.GrantTypes.Password,
                UserName = username,
                Password = password
            };

            var pathProvider = new PathProvider<OAuth2TokenV1Request>();

            var path = pathProvider.GetPath(model);

            var request = new RestRequest(path, Method.POST);

            var factory = new QueryStringBuilderFactory();

            _ = request.AddHeader("cache-control", "no-cache");

            string encoded = factory.Create()
                .Add(model)
                .ToString();

            _ = request.AddParameter(
                ContentTypeConstants.Application.FormUrlEncoded,
                encoded,
                ContentTypeConstants.Application.FormUrlEncoded,
                ParameterType.RequestBody);

            var response = await client
                .ExecuteTaskAsync<OAuth2TokenV1Response>(request, cancellationToken)
                .ConfigureAwait(Await.Default);

            if (response.IsSuccessful == true)
            {
                _token = response.Data;

                var expires = DateTimeOffset.UtcNow;

                if (_token.ExpiresIn.HasValue == true)
                {
                    expires = expires
                        .AddSeconds(_token.ExpiresIn.Value)
                        .AddMinutes(-2);
                }

                _token.Expires = expires;

                return _token.AccessToken;
            }

            return null;
        }
    }
}
