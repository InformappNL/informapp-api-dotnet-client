using Informapp.InformSystem.WebApi.Models.Arguments;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Models.ExampleValues
{
    internal class ExampleStream : ExampleStreamBase,
        IExampleStream,
        IDisposable
    {
        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

        private readonly MemoryStream _stream;

        public ExampleStream(
            MemoryStream stream) : base()
        {
            Argument.NotNull(stream, nameof(stream));

            _stream = stream;
        }

        public override long Length => _stream.Length;

        public override async Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
        {
            await _semaphoreSlim
                .WaitAsync()
                .ConfigureAwait(Await.Default);

            try
            {
                await _stream
                    .CopyToAsync(destination, bufferSize, cancellationToken)
                    .ConfigureAwait(Await.Default);

                // Restore position so using the stream for the next example works
                _stream.Position = 0L;
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        public override bool Equals(object obj)
        {
            return _stream.Equals(obj);
        }

        public override int GetHashCode()
        {
            return _stream.GetHashCode();
        }

        public override string ToString()
        {
            return _stream.ToString();
        }

        public void Dispose()
        {
            _semaphoreSlim.Dispose();

            _stream.Dispose();
        }
    }
}
