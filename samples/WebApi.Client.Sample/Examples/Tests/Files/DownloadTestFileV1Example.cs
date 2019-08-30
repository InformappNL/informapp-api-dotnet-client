using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Models.Http;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Files.DownloadTestFile;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.Tests.Files
{
    internal class DownloadTestFileV1Example : IExample
    {
        private readonly IApiClient<DownloadTestFileV1Request, DownloadTestFileV1Response> _client;

        public DownloadTestFileV1Example(
            IApiClient<DownloadTestFileV1Request, DownloadTestFileV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        public async Task Run(CancellationToken cancellationToken)
        {
            var request = new DownloadTestFileV1Request
            {
                Kind = DownloadTestFileV1RequestKind.Pdf,
            };

            var response = await _client.Execute(request, cancellationToken)
                .ThrowIfFailed();

            string directory = Path.GetTempPath();

            directory = Path.Combine(directory, nameof(DownloadTestFileV1Example));

            Directory.CreateDirectory(directory);

            string filename = Path.GetRandomFileName() + '_' + response.Model.FileName;

            string path = Path.Combine(directory, filename);

            long bytesWritten = 0;

            using (response.Model)
            using (var stream = response.Model.File)
            using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                byte[] buffer = new byte[16 * 1024];

                int read;

                while ((read = await stream.ReadAsync(buffer, 0, buffer.Length, cancellationToken)) > 0)
                {
                    await fileStream.WriteAsync(buffer, 0, read, cancellationToken);

                    bytesWritten += read;
                }
            }

            Console.WriteLine("Saved download file to {0} ({1:n0} bytes)", path, bytesWritten);

            if (response.Headers.ContentLength != bytesWritten)
            {
                throw new Exception("Number of bytes written not equal to content length");
            }
        }
    }
}
