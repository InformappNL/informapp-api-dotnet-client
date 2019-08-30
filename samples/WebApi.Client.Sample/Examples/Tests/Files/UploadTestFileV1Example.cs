using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Files.UploadTestFile;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.Tests.Files
{
    internal class UploadTestFileV1Example : IExample
    {
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
            using (var request = GetInMemoryFileRequest())
            //using (var request = GetFileFromFileSystem())
            {
                var response = await _client
                    .Execute(request, cancellationToken)
                    .ThrowIfFailed()
                    .ConfigureAwait(WebApiClientSampleProjectSettings.ConfigureAwait);

                request.File.Position = 0L;

                byte[] md5hash;

#pragma warning disable CA1508 // Avoid dead conditional code. - Faulty rule?
#pragma warning disable CA5351 // Broken cryptographic algorithm MD5 - not an issue, used to compare local and remote hash of uploaded file
                using (var algorithm = MD5.Create())
#pragma warning restore CA5351
#pragma warning restore CA1508
                {
                    md5hash = algorithm.ComputeHash(request.File);
                }

                bool hashEquals = Equals(response.Model.MD5Checksum, md5hash);

                if (hashEquals == false)
                {
                    throw new InvalidOperationException("file upload failed, hashes differ.");
                }

                if (response.Model.Size != request.File.Length)
                {
                    throw new InvalidOperationException("file upload failed, file sizes differ.");
                }
            }
        }

        private static UploadTestFileV1Request GetInMemoryFileRequest()
        {
            var stream = new MemoryStream();

            using (var writer = new StreamWriter(stream, Encoding.UTF8, 1024, true))
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

        protected static UploadTestFileV1Request GetFileFromFileSystem()
        {
            var stream = File.OpenRead(PathToFile);

            string fileName = Path.GetFileName(PathToFile);

            var request = new UploadTestFileV1Request
            {
                File = stream,
                FileName = fileName,
                Size = stream.Length,
            };

            return request;
        }

        private static bool Equals(byte[] left, byte[] right)
        {
            if (left == null && right == null)
            {
                return true;
            }

            if (left == null || right == null)
            {
                return false;
            }

            if (left.Length != right.Length)
            {
                return false;
            }

            int length = left.Length;

            for (int i = 0; i < length; i++)
            {
                if (left[i] != right[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
