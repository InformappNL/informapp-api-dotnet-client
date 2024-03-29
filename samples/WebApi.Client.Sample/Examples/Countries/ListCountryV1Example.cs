﻿using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Countries.ListCountry;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Examples.Countries
{
    /// <summary>
    /// Example for list country
    /// </summary>
    public class ListCountryV1Example : IExample
    {
        private readonly IApiClient<ListCountryV1Request, ListCountryV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListCountryV1Example"/> class.
        /// </summary>
        public ListCountryV1Example(
            IApiClient<ListCountryV1Request, ListCountryV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        /// <summary>
        /// Execute example
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task</returns>
        public async Task Execute(CancellationToken cancellationToken)
        {
            var model = new ListCountryV1Request
            {

            };

            var getResponse = await Get(model, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(getResponse, nameof(getResponse));



            var headResponse = await Head(model, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(headResponse, nameof(headResponse));
        }

        private Task<ApiResponse<ListCountryV1Response>> Get(ListCountryV1Request request, CancellationToken cancellationToken)
        {
            return _client.Execute(request, cancellationToken);
        }

        private Task<ApiResponse<ListCountryV1Response>> Head(ListCountryV1Request model, CancellationToken cancellationToken)
        {
            var request = ApiRequest.Create(model)
                .Head();

            return _client.Execute(request, cancellationToken);
        }
    }
}
