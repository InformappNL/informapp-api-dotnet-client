using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Exports;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.Integrations
{
    internal class AcceptIntegrationExportV1Example : IExample
    {
        private readonly IApiClient<AcceptIntegrationExportV1Request, AcceptIntegrationExportV1Response> _client;

        public AcceptIntegrationExportV1Example(
            IApiClient<AcceptIntegrationExportV1Request, AcceptIntegrationExportV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            var integrationExportId = Guid.Parse("64064995-E24B-4C38-8DCA-DD32C29793AB");

            var request = new AcceptIntegrationExportV1Request
            {
                IntegrationExportId = integrationExportId,
            };

            var response = await _client
                .Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
