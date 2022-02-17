using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Exports;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Examples.Integrations
{
    /// <summary>
    /// Example for accept integration export
    /// </summary>
    public class AcceptIntegrationExportV1Example : IExample
    {
        private readonly IApiClient<AcceptIntegrationExportV1Request, AcceptIntegrationExportV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="AcceptIntegrationExportV1Example"/> class.
        /// </summary>
        public AcceptIntegrationExportV1Example(
            IApiClient<AcceptIntegrationExportV1Request, AcceptIntegrationExportV1Response> client)
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
