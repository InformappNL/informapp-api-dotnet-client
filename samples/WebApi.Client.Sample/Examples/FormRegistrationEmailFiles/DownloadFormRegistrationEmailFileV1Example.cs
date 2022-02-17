using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationEmailFiles.Download;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Examples.FormRegistrationEmailFiles
{
    /// <summary>
    /// Example for download form registration email file
    /// </summary>
    public class DownloadFormRegistrationEmailFileV1Example : IExample
    {
        // Set form registration email file id
        private const string FormRegistrationEmailFileId = "12B0D2CB-95BC-479F-9452-38691ED48430";

        private const int BufferSize = 1024 * 16;

        private readonly IApiClient<DownloadFormRegistrationEmailFileV1Request, DownloadFormRegistrationEmailFileV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadFormRegistrationEmailFileV1Example"/> class.
        /// </summary>
        public DownloadFormRegistrationEmailFileV1Example(
            IApiClient<DownloadFormRegistrationEmailFileV1Request, DownloadFormRegistrationEmailFileV1Response> client)
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
            var formRegistrationEmailFileId = Guid.Parse(FormRegistrationEmailFileId);

            var request = new DownloadFormRegistrationEmailFileV1Request
            {
                FormRegistrationEmailFileId = formRegistrationEmailFileId,
            };

            var response = await _client
                .Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            string directory = Path.GetTempPath();

            directory = Path.Combine(directory, nameof(DownloadFormRegistrationEmailFileV1Example));

            _ = Directory.CreateDirectory(directory);

            string filename = Path.GetRandomFileName() + '_' + response.Model.FileName;

            string path = Path.Combine(directory, filename);

            long bytesWritten = 0L;

            using (response.Model)
            using (var stream = response.Model.File)
#pragma warning disable CA1508 // Avoid dead conditional code
            using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, BufferSize, useAsync: true))
#pragma warning restore CA1508 // Avoid dead conditional code
            {
                byte[] buffer = new byte[BufferSize];

                int read;

#pragma warning disable CA1835 // Prefer the 'Memory'-based overloads for 'ReadAsync' and 'WriteAsync'
                while ((read = await stream
                    .ReadAsync(buffer, 0, buffer.Length, cancellationToken)
#pragma warning restore CA1835 // Prefer the 'Memory'-based overloads for 'ReadAsync' and 'WriteAsync'
                    .ConfigureAwait(Await.Default)) > 0)
                {
#pragma warning disable CA1835 // Prefer the 'Memory'-based overloads for 'ReadAsync' and 'WriteAsync'
                    await fileStream
                        .WriteAsync(buffer, 0, read, cancellationToken)
#pragma warning restore CA1835 // Prefer the 'Memory'-based overloads for 'ReadAsync' and 'WriteAsync'
                        .ConfigureAwait(Await.Default);

                    bytesWritten += read;
                }

                await fileStream
                    .FlushAsync(cancellationToken)
                    .ConfigureAwait(Await.Default);
            }

#pragma warning disable CA1303 // Do not pass literals as localized parameters
            Console.WriteLine("Saved download file to {0} ({1:n0} bytes)", path, bytesWritten);
#pragma warning restore CA1303 // Do not pass literals as localized parameters

            if (response.Headers.ContentLength != bytesWritten)
            {
                throw new InvalidOperationException("Number of bytes written not equal to content length");
            }
        }
    }
}
