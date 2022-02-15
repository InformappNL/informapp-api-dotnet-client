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
    /// Example for accept integration export
    /// </summary>
    public class StartIntegrationImportV1Example : IExample
    {
        private readonly IApiClient<StartIntegrationImportV1Request, StartIntegrationImportV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="StartIntegrationImportV1Example"/> class.
        /// </summary>
        public StartIntegrationImportV1Example(
            IApiClient<StartIntegrationImportV1Request, StartIntegrationImportV1Response> client)
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
            var integrationId = Guid.Parse("28830026-3115-4C03-9A15-E634C0BDA2FD");
            var remoteImportGuid = Guid.Parse("F2562C6C-D7F7-4E72-9CBD-9B6153148571");

            var fileName = "example.xlsx";
            var fileSize = 3000L;
            var fileDate = DateTimeOffset.UtcNow;

            var request = new StartIntegrationImportV1Request
            {
                IntegrationId = integrationId,
                RemoteImportId = remoteImportGuid,
                FileName = fileName,
                FileSize = fileSize,
                FileDate = fileDate,
            };

            var response = await _client
                .Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
