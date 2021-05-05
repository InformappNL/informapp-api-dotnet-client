using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Exports;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.Integrations
{
    internal class ListIntegrationExportQueuedForMeV1Example : IExample
    {
        private readonly IApiClient<ListIntegrationExportQueuedForMeV1Request, ListIntegrationExportQueuedForMeV1Response> _client;

        public ListIntegrationExportQueuedForMeV1Example(
            IApiClient<ListIntegrationExportQueuedForMeV1Request, ListIntegrationExportQueuedForMeV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

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
