﻿using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.AppGroups.ListAppGroup;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Examples.AppGroups
{
    /// <summary>
    /// Example for list app group
    /// </summary>
    public class ListAppGroupV1Example : IExample
    {
        private readonly IApiClient<ListAppGroupV1Request, ListAppGroupV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListAppGroupV1Example"/> class.
        /// </summary>
        public ListAppGroupV1Example(
            IApiClient<ListAppGroupV1Request, ListAppGroupV1Response> client)
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
            var request = new ListAppGroupV1Request
            {
                Sort = new[] { ListAppGroupV1Sort.Name },
                PageNumber = 1,
                PageSize = 50
            };

            var response = await _client.Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
