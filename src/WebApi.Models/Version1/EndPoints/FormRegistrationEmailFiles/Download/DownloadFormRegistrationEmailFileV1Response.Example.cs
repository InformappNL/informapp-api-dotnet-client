using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationEmailFiles.Download
{
    public partial class DownloadFormRegistrationEmailFileV1Response : IExampleMemberProvider
    {
        private const string FormRegistrationEmailFileProjectContentExample =
            @"7VbGV8SioOjL/C5/yyaTsYPmnQhRJMNqCTOgPtmdYX4hCsD0LHKniqlIATgSFj78GRZrDjmAY6PBSX5tEQfm0A==";

        static DownloadFormRegistrationEmailFileV1Response()
        {
            if (ExampleAttributeConfiguration.Enabled == true)
            {
                _ = _container.Add(nameof(File), GetFileExample());
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static readonly ExampleValuesContainer _container = new ExampleValuesContainer();

#pragma warning disable CA1033 // Interface methods should be callable by child types
        object IExampleMemberProvider.GetExample(string name)
#pragma warning restore CA1033 // Interface methods should be callable by child types
        {
            return _container.GetExample(name);
        }

        private static Stream GetFileExample()
        {
            var stream = new MemoryStream();

            using (var writer = new StreamWriter(stream, Encoding.UTF8, 1024, true))
            {
                writer.Write(FormRegistrationEmailFileProjectContentExample);

                writer.Flush();

                stream.Position = 0L;
            }

            var file = new ExampleStream(stream);

            return file;
        }

#pragma warning disable IDE0051 // Remove unused private members
        private static void Assignable(DownloadFormRegistrationEmailFileV1Response response)
#pragma warning restore IDE0051 // Remove unused private members
        {
            response.File = GetFileExample();
        }
    }
}
