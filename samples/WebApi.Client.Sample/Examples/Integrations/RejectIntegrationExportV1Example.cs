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
    /// <summary>
    /// Example for reject integration export
    /// </summary>
    public class RejectIntegrationExportV1Example : IExample
    {
        private readonly IApiClient<RejectIntegrationExportV1Request, RejectIntegrationExportV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="RejectIntegrationExportV1Example"/> class.
        /// </summary>
        public RejectIntegrationExportV1Example(
            IApiClient<RejectIntegrationExportV1Request, RejectIntegrationExportV1Response> client)
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

            var request = new RejectIntegrationExportV1Request
            {
                IntegrationExportId = integrationExportId,
                Message = "Not configured for this integration",
            };

            var response = await _client
                .Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
