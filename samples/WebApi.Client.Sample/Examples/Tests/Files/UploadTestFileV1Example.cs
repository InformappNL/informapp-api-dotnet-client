﻿using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Files.UploadTestFile;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Examples.Tests.Files
{
    /// <summary>
    /// Example for upload test file
    /// </summary>
    public class UploadTestFileV1Example : IExample
    {
        private const int BufferSize = 1024 * 16;

        private const string PathToFile = "C:/Path/To/File.txt"; // Set path + filename here to upload file from file system

        private readonly IApiClient<UploadTestFileV1Request, UploadTestFileV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadTestFileV1Example"/> class.
        /// </summary>
        public UploadTestFileV1Example(
            IApiClient<UploadTestFileV1Request, UploadTestFileV1Response> client)
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
            using (var model = GetInMemoryFileRequest())
            //using (var model = GetFileFromFileSystem())
#pragma warning restore IDE0063 // Use simple 'using' statement
            {
                var request = ApiRequest.Create(model);

                var response = await _client
                    .Execute(request, cancellationToken)
                    .ThrowIfFailed()
                    .ConfigureAwait(Await.Default);
            }
        }

        private static UploadTestFileV1Request GetInMemoryFileRequest()
        {
            var stream = new MemoryStream();

            using (var writer = new StreamWriter(stream, Encoding.UTF8, BufferSize, leaveOpen: true))
            {
                writer.WriteLine("example");
            }

            stream.Position = 0L;

            string fileName = "example.txt";

            var request = new UploadTestFileV1Request
            {
                File = stream,
                FileName = fileName,
                Size = stream.Length,
            };

            return request;
        }

#pragma warning disable IDE0051 // Remove unused private members
        private static UploadTestFileV1Request GetFileFromFileSystem()
#pragma warning restore IDE0051 // Remove unused private members
        {
            var stream = new FileStream(PathToFile, FileMode.Open, FileAccess.Read, FileShare.Read, BufferSize, useAsync: true);

            string fileName = Path.GetFileName(PathToFile);

            var request = new UploadTestFileV1Request
            {
                File = stream,
                FileName = fileName,
                Size = stream.Length,
            };

            return request;
        }
    }
}
