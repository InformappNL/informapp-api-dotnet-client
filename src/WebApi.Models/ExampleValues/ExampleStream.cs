using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Models.ExampleValues
{
    internal class ExampleStream : ExampleStreamBase,
        IDisposable
    {
        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

        private readonly MemoryStream _stream;

        public ExampleStream(
            MemoryStream stream) : base()
        {
            _stream = stream;
        }

        public override async Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
        {
            await _semaphoreSlim.WaitAsync();

            try
            {
                await _stream.CopyToAsync(destination, bufferSize, cancellationToken);

                // Restore position so using the stream for the next example works
                _stream.Position = 0L;
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        public void Dispose()
        {
            _semaphoreSlim.Dispose();

            _stream.Dispose();
        }
    }
}
