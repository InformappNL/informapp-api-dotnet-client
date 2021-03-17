using Informapp.InformSystem.WebApi.Models.ExampleValues;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Files.DownloadTestFile
{
    public partial class DownloadTestFileV1Response : IExampleMemberProvider
    {
        static DownloadTestFileV1Response()
        {
            if (ExampleAttributeConfiguration.Enabled == true)
            {
                _ = _container.Add(nameof(File), GetFileExample());
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static readonly ExampleValuesContainer _container = new ExampleValuesContainer();

        object IExampleMemberProvider.GetExample(string name)
        {
            return _container.GetExample(name);
        }

        private static Stream GetFileExample()
        {
            var stream = new MemoryStream();

            using (var writer = new StreamWriter(stream, Encoding.UTF8, 1024, leaveOpen: true))
            {
                writer.Write("This is an example text file");

                writer.Flush();

                stream.Position = 0L;
            }

            var file = new ExampleStream(stream);

            return file;
        }

        private static void Assignable(DownloadTestFileV1Response response)
        {
            response.File = GetFileExample();
        }
    }
}
