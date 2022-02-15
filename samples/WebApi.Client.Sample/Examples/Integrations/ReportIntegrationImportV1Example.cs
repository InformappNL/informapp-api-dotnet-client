using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Imports;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.Integrations
{
    /// <summary>
    /// Example for report integration import
    /// </summary>
    public class ReportIntegrationImportV1Example : IExample
    {
        private readonly IApiClient<ReportIntegrationImportV1Request, ReportIntegrationImportV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportIntegrationImportV1Example"/> class.
        /// </summary>
        public ReportIntegrationImportV1Example(
            IApiClient<ReportIntegrationImportV1Request, ReportIntegrationImportV1Response> client)
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
            var integrationImportId = Guid.Parse("64064995-E24B-4C38-8DCA-DD32C29793AB");

            var duration = 500;

            var request = new ReportIntegrationImportV1Request
            {
                IntegrationImportId = integrationImportId,
                Result = UploadIntegrationImportV1Result.Success,
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
