using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.AppUsers.DeleteAppUser;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Examples.AppUsers
{
    /// <summary>
    /// Example for delete app user
    /// </summary>
    public class DeleteAppUserV1Example : IExample
    {
        private readonly IApiClient<DeleteAppUserV1Request, DeleteAppUserV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteAppUserV1Example"/> class.
        /// </summary>
        public DeleteAppUserV1Example(
            IApiClient<DeleteAppUserV1Request, DeleteAppUserV1Response> client)
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
