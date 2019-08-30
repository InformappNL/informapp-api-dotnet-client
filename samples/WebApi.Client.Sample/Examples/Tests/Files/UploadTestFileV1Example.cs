using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Files.UploadTestFile;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.Tests.Files
{
    internal class UploadTestFileV1Example : IExample
    {
        private const int BufferSize = 1024 * 16;

        private const string PathToFile = "C:/Path/To/File.txt"; // Set path + filename here to upload file from file system

        private readonly IApiClient<UploadTestFileV1Request, UploadTestFileV1Response> _client;

        public UploadTestFileV1Example(
            IApiClient<UploadTestFileV1Request, UploadTestFileV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            using (var model = GetInMemoryFileRequest())
            //using (var model = GetFileFromFileSystem())
            {
                var request = ApiRequest.Create(model);

                var response = await _client
                    .Execute(request, cancellationToken)
                    .ThrowIfFailed()
                    .ConfigureAwait(Await.Default);
            }
        }

#pragma warning disable IDE0051 // Remove unused private members
        private static UploadTestFileV1Request GetInMemoryFileRequest()
#pragma warning restore IDE0051 // Remove unused private members
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
