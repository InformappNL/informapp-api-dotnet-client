using Informapp.InformSystem.WebApi.Client.Arguments;
using Informapp.InformSystem.WebApi.Client.Streams;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Cryptography
{
    /// <summary>
    /// Class to compute hash codes
    /// </summary>
    public class Hasher : IHasher
    {
        private const int BufferSize = 1024 * 16;

        /// <summary>
        /// Computes the hash value for the specified <see cref="Stream"/> object.
        /// </summary>
        /// <param name="hashAlgorithm">The cryptographic hash algorithm.</param>
        /// <param name="stream">The input to compute the hash code for.</param>
        /// <returns>The computed hash code.</returns>
        public byte[] ComputeHash(HashAlgorithm hashAlgorithm, Stream stream)
        {
            Argument.NotNull(hashAlgorithm, nameof(hashAlgorithm));
            Argument.NotNull(stream, nameof(stream));

            return hashAlgorithm.ComputeHash(stream);
        }

        /// <summary>
        /// Computes the hash value for the specified <see cref="Stream"/> object asynchronously.
        /// </summary>
        /// <param name="hashAlgorithm">The cryptographic hash algorithm.</param>
        /// <param name="stream">The input to compute the hash code for.</param>
        /// <returns>A task that represents the asynchronous compute operation. The value of the task's <see cref="Task{TResult}.Result"/> parameter contains the computed hash code.</returns>
        public Task<byte[]> ComputeHashAsync(HashAlgorithm hashAlgorithm, Stream stream)
        {
            Argument.NotNull(hashAlgorithm, nameof(hashAlgorithm));
            Argument.NotNull(stream, nameof(stream));

            return ComputeHashAsync(hashAlgorithm, stream);
        }

        /// <summary>
        /// Computes the hash value for the specified <see cref="Stream"/> object asynchronously.
        /// </summary>
        /// <param name="hashAlgorithm">The cryptographic hash algorithm.</param>
        /// <param name="stream">The input to compute the hash code for.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous compute operation. The value of the task's <see cref="Task{TResult}.Result"/> parameter contains the computed hash code.</returns>
        public async Task<byte[]> ComputeHashAsync(HashAlgorithm hashAlgorithm, Stream stream, CancellationToken cancellationToken)
        {
            Argument.NotNull(hashAlgorithm, nameof(hashAlgorithm));
            Argument.NotNull(stream, nameof(stream));

            using (var decoratedStream = new ControlDisposalStreamDecorator(stream, leaveOpen: true))
            using (var cryptoStream = new CryptoStream(decoratedStream, hashAlgorithm, CryptoStreamMode.Read))
            {
                byte[] buffer = new byte[BufferSize];

                int read;

                while ((read = await cryptoStream
                    .ReadAsync(buffer, 0, buffer.Length, cancellationToken)
                    .ConfigureAwait(Await.Default)) > 0)
                {

                }

                return hashAlgorithm.Hash;
            }
        }
    }
}
