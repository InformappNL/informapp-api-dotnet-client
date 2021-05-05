using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Models.ExampleValues
{
    /// <summary>
    /// Example stream interface
    /// </summary>
#pragma warning disable CA1711 // Identifiers should not have incorrect suffix
    public interface IExampleStream
#pragma warning restore CA1711 // Identifiers should not have incorrect suffix
    {
        /// <summary>
        /// Gets the length of the stream in bytes.
        /// </summary>
        /// <returns>The length of the stream in bytes.</returns>
        long Length { get; }

        /// <summary>
        /// Asynchronously reads all the bytes from the current stream and writes them to another stream, using a specified buffer size and cancellation token.
        /// </summary>
        /// <param name="destination">The stream to which the contents of the current stream will be copied.</param>
        /// <param name="bufferSize">The size, in bytes, of the buffer. This value must be greater than zero.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous copy operation.</returns>
        Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken);
    }
}
