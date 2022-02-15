﻿using Informapp.InformSystem.WebApi.Models.ExampleValues;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Imports
{
    public partial class UploadIntegrationImportV1Request : IExampleMemberProvider
    {
        private const string IntegrationImportProjectContentExample =
@"Id ProjectId CustomerId Name
1  38        8          Building 21
2  102       17         Channel Tunnel
3  57        42         Euro Gate
4  86        32         The New Holland Bridge";

        static UploadIntegrationImportV1Request()
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
                writer.Write(IntegrationImportProjectContentExample);

                writer.Flush();

                stream.Position = 0L;
            }

            var file = new ExampleStream(stream);

            return file;
        }

#pragma warning disable IDE0051 // Remove unused private members
        private static void Assignable(UploadIntegrationImportV1Request request)
#pragma warning restore IDE0051 // Remove unused private members
        {
            request.File = GetFileExample();
        }
    }
}
