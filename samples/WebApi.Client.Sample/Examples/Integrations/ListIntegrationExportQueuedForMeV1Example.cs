using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Exports;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Examples.Integrations
{
    /// <summary>
    /// Example for list integration export
    /// </summary>
    public class ListIntegrationExportQueuedForMeV1Example : IExample
    {
        private readonly IApiClient<ListIntegrationExportQueuedForMeV1Request, ListIntegrationExportQueuedForMeV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListIntegrationExportQueuedForMeV1Example"/> class.
        /// </summary>
        public ListIntegrationExportQueuedForMeV1Example(
            IApiClient<ListIntegrationExportQueuedForMeV1Request, ListIntegrationExportQueuedForMeV1Response> client)
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
            var request = new ListIntegrationExportQueuedForMeV1Request
            {
                PageNumber = 1,
                PageSize = 10,
            };

            var response = await _client.Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
