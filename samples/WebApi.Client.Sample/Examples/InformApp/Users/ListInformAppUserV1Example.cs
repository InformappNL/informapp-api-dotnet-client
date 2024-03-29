﻿using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Users.ListUser;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Examples.InformApp.Users
{
    /// <summary>
    /// Example for list app user
    /// </summary>
    public class ListInformAppUserV1Example : IExample
    {
        private readonly IApiClient<ListInformAppUserV1Request, ListInformAppUserV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListInformAppUserV1Example"/> class.
        /// </summary>
        public ListInformAppUserV1Example(
            IApiClient<ListInformAppUserV1Request, ListInformAppUserV1Response> client)
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
            var businessGroupId = Guid.Parse("edc7c3f4-47b4-44ba-b8d6-017a178ad910");

            var request = new ListInformAppUserV1Request
            {
                BusinessGroupId = businessGroupId,
                PageNumber = 1,
                PageSize = 100
            };

            var response = await _client.Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
