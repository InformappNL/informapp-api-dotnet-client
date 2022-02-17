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
    /// Example for report integration export
    /// </summary>
    public class ReportIntegrationExportV1Example : IExample
    {
        private readonly IApiClient<ReportIntegrationExportV1Request, ReportIntegrationExportV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportIntegrationExportV1Example"/> class.
        /// </summary>
        public ReportIntegrationExportV1Example(
            IApiClient<ReportIntegrationExportV1Request, ReportIntegrationExportV1Response> client)
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
            var integrationExportLogId = Guid.Parse("A870F76B-CBD6-4A2A-80F4-E09D01718364");

            var duration = 500;

            var request = new ReportIntegrationExportV1Request
            {
                IntegrationExportId = integrationExportId,
                IntegrationExportLogId = integrationExportLogId,
                Result = DownloadIntegrationExportV1Result.Success,
                Duration = duration,
                Message = "Success",
                Exception = ""
            };

            var response = await _client
                .Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
