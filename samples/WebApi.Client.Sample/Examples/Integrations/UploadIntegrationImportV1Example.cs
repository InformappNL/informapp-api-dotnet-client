using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Imports;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.IntegrationImports
{
    /// <summary>
    /// Example for upload integration import
    /// </summary>
    public class UploadIntegrationImportV1Example : IExample
    {
        // Set integration import id
        private const string IntegrationImportId = "eca97d10-fb59-4e04-8832-3892d46f6861";

        private readonly IApiClient<UploadIntegrationImportV1Request, UploadIntegrationImportV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadIntegrationImportV1Example"/> class.
        /// </summary>
        public UploadIntegrationImportV1Example(
            IApiClient<UploadIntegrationImportV1Request, UploadIntegrationImportV1Response> client)
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
#pragma warning disable IDE0063 // Use simple 'using' statement
            using (var model = GetRequest())
#pragma warning restore IDE0063 // Use simple 'using' statement
            {
                var request = ApiRequest.Create(model);

                var response = await _client.Execute(request, cancellationToken)
                    .ThrowIfFailed()
                    .ConfigureAwait(Await.Default);

                Require.NotNull(response, nameof(response));
            }
        }

        private static UploadIntegrationImportV1Request GetRequest()
        {
            var integrationImportId = Guid.Parse(IntegrationImportId);

            var fileName = "example.xlsx";

            var file = typeof(UploadIntegrationImportV1Example).Assembly.GetManifestResourceStream(fileName);
            var fileSize = file.Length;

            var request = new UploadIntegrationImportV1Request
            {
                IntegrationImportId = integrationImportId,
                File = file,
                FileName = fileName,
                Size = fileSize,
            };

            return request;
        }
    }
}
