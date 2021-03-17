using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Users.ListUser;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.InformApp.Users
{
    internal class ListInformAppUserV1Example : IExample
    {
        private readonly IApiClient<ListInformAppUserV1Request, ListInformAppUserV1Response> _client;

        public ListInformAppUserV1Example(
            IApiClient<ListInformAppUserV1Request, ListInformAppUserV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

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
