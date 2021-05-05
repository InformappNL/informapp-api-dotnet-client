﻿using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Exports;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.Integrations
{
    /// <summary>
    /// Example for download integration export
    /// </summary>
    public class DownloadIntegrationExportV1Example : IExample
    {
        // Set integration export id
        private const string IntegrationExportId = "A0125378-7C02-40C4-9B21-1908871FC2DE";

        private const int BufferSize = 1024 * 16;

        private readonly IApiClient<DownloadIntegrationExportV1Request, DownloadIntegrationExportV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadIntegrationExportV1Example"/> class.
        /// </summary>
        public DownloadIntegrationExportV1Example(
            IApiClient<DownloadIntegrationExportV1Request, DownloadIntegrationExportV1Response> client)
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
            var integrationExportId = Guid.Parse(IntegrationExportId);

            var request = new DownloadIntegrationExportV1Request
            {
                IntegrationExportId = integrationExportId,
            };

            var response = await _client
                .Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            string directory = Path.GetTempPath();

            directory = Path.Combine(directory, nameof(DownloadIntegrationExportV1Example));

            _ = Directory.CreateDirectory(directory);

            string filename = Path.GetRandomFileName() + '_' + response.Model.FileName;

            string path = Path.Combine(directory, filename);

            long bytesWritten = 0L;

            using (response.Model)
            using (var stream = response.Model.File)
            using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, BufferSize, useAsync: true))
            {
                byte[] buffer = new byte[BufferSize];

                int read;

                while ((read = await stream
                    .ReadAsync(buffer, 0, buffer.Length, cancellationToken)
                    .ConfigureAwait(Await.Default)) > 0)
                {
                    await fileStream
                        .WriteAsync(buffer, 0, read, cancellationToken)
                        .ConfigureAwait(Await.Default);

                    bytesWritten += read;
                }

                await fileStream
                    .FlushAsync(cancellationToken)
                    .ConfigureAwait(Await.Default);
            }

            Console.WriteLine("Saved export file to {0} ({1:n0} bytes)", path, bytesWritten);

            if (response.Headers.ContentLength != bytesWritten)
            {
                throw new InvalidOperationException("Number of bytes written not equal to content length");
            }
        }
    }
}
