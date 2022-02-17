using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.AppGroups.DeleteAppGroup;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Examples.AppGroups
{
    /// <summary>
    /// Example for delete app group
    /// </summary>
    public class DeleteAppGroupV1Example : IExample
    {
        private readonly IApiClient<DeleteAppGroupV1Request, DeleteAppGroupV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteAppGroupV1Example"/> class.
        /// </summary>
        public DeleteAppGroupV1Example(
            IApiClient<DeleteAppGroupV1Request, DeleteAppGroupV1Response> client)
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
            var request = new DeleteAppGroupV1Request
            {
                AppGroupId = Guid.Empty // App group id here
            };

            var response = await _client.Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
