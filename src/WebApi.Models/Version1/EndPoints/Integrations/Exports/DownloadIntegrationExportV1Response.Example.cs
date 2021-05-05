using Informapp.InformSystem.WebApi.Models.ExampleValues;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Exports
{
    public partial class DownloadIntegrationExportV1Response : IExampleMemberProvider
    {
        private const string DataSourceProjectContentExample =
@"Id ProjectId CustomerId Name
1  38        8          Building 21
2  102       17         Channel Tunnel
3  57        42         Euro Gate
4  86        32         The New Holland Bridge";

        static DownloadIntegrationExportV1Response()
        {
            if (ExampleAttributeConfiguration.Enabled == true)
            {
                _container.Add(nameof(File), GetFileExample());
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

            using (var writer = new StreamWriter(stream, Encoding.UTF8, 1024, true))
            {
                writer.Write(DataSourceProjectContentExample);

                writer.Flush();

                stream.Position = 0L;
            }

            var file = new ExampleStream(stream);

            return file;
        }

        private static void Assignable(DownloadIntegrationExportV1Response response)
        {
            response.File = GetFileExample();
        }
    }
}
