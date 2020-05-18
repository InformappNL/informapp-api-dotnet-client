using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppUsers.DeleteAppUser;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.AppUsers
{
    internal class DeleteAppUserV1Example : IExample
    {
        private readonly IApiClient<DeleteAppUserV1Request, DeleteAppUserV1Response> _client;

        public DeleteAppUserV1Example(
            IApiClient<DeleteAppUserV1Request, DeleteAppUserV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            var request = new DeleteAppUserV1Request
            {
                AppUserId = Guid.Empty // App user id here
            };

            var response = await _client
                .Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
