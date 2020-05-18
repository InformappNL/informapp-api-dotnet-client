using System;
using System.IO;

namespace Informapp.InformSystem.WebApi.Client.Sample.Consoles
{
    internal static class ConsoleHelper
    {
        public static void SetInputBufferSize(int bufferSize)
        {
            if (bufferSize < 10)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize));
            }

            var stream = Console.OpenStandardInput(bufferSize);

#pragma warning disable CA2000 // Dispose objects before losing scope
            var reader = new StreamReader(stream, Console.InputEncoding, detectEncodingFromByteOrderMarks: false, bufferSize);
#pragma warning restore CA2000 // Dispose objects before losing scope

            Console.SetIn(reader);
        }
    }
}
