using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Cryptography
{
    /// <summary>
    /// Interface to compute hash codes
    /// </summary>
    public interface IHasher
    {
        /// <summary>
        /// Computes the hash value for the specified <see cref="Stream"/> object.
        /// </summary>
        /// <param name="hashAlgorithm">The cryptographic hash algorithm.</param>
        /// <param name="stream">The input to compute the hash code for.</param>
        /// <returns>The computed hash code.</returns>
        byte[] ComputeHash(HashAlgorithm hashAlgorithm, Stream stream);

        /// <summary>
        /// Computes the hash value for the specified <see cref="Stream"/> object asynchronously.
        /// </summary>
        /// <param name="hashAlgorithm">The cryptographic hash algorithm.</param>
        /// <param name="stream">The input to compute the hash code for.</param>
        /// <returns>A task that represents the asynchronous compute operation. The value of the task's <see cref="Task{TResult}.Result"/> parameter contains the computed hash code.</returns>
        Task<byte[]> ComputeHashAsync(HashAlgorithm hashAlgorithm, Stream stream);

        /// <summary>
        /// Computes the hash value for the specified <see cref="Stream"/> object asynchronously.
        /// </summary>
        /// <param name="hashAlgorithm">The cryptographic hash algorithm.</param>
        /// <param name="stream">The input to compute the hash code for.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous compute operation. The value of the task's <see cref="Task{TResult}.Result"/> parameter contains the computed hash code.</returns>
        Task<byte[]> ComputeHashAsync(HashAlgorithm hashAlgorithm, Stream stream, CancellationToken cancellationToken);
    }
}
