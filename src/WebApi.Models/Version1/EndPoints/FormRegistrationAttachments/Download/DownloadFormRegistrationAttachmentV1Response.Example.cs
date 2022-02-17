using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationAttachments.Download
{
    public partial class DownloadFormRegistrationAttachmentV1Response : IExampleMemberProvider
    {
        private const string FormRegistrationAttachmentProjectContentExample =
            @"/izOwbKmfMjE1Bysf63S2zHu7rrYoIRtbGhIdumoONJWROhj748Cj4X+pl+lTiupsiNSAtzJteEl/ue44eeytQ==";

        static DownloadFormRegistrationAttachmentV1Response()
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
                writer.Write(FormRegistrationAttachmentProjectContentExample);

                writer.Flush();

                stream.Position = 0L;
            }

            var file = new ExampleStream(stream);

            return file;
        }

#pragma warning disable IDE0051 // Remove unused private members
        private static void Assignable(DownloadFormRegistrationAttachmentV1Response response)
#pragma warning restore IDE0051 // Remove unused private members
        {
            response.File = GetFileExample();
        }
    }
}
