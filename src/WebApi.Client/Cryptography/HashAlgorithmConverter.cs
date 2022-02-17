using ConnectedDevelopment.InformSystem.WebApi.Client.Converters;
using System;
using System.Security.Cryptography;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Cryptography
{
    /// <summary>
    /// Implementation of <see cref="IConverter{TSource, TResult}"/>
    /// to convert <see cref="HashAlgorithmKind"/> to <see cref="HashAlgorithm"/>
    /// </summary>
    public class HashAlgorithmConverter : IConverter<HashAlgorithmKind?, HashAlgorithm>
    {
        /// <summary>
        /// Convert <see cref="HashAlgorithmKind"/> to <see cref="HashAlgorithm"/>
        /// </summary>
        /// <param name="source">The source value</param>
        /// <returns>The <see cref="ConvertResult{TResult}"/> containing the converted value</returns>
        public ConvertResult<HashAlgorithm> Convert(HashAlgorithmKind? source)
        {
            HashAlgorithm hashAlgorithm = null;

            if (source.HasValue == true)
            {
                switch (source)
                {
                    case HashAlgorithmKind.SHA256:
#pragma warning disable CA2000 // Dispose objects before losing scope
                        hashAlgorithm = SHA256.Create();
#pragma warning restore CA2000 // Dispose objects before losing scope
                        break;
                    case HashAlgorithmKind.SHA384:
#pragma warning disable CA2000 // Dispose objects before losing scope
                        hashAlgorithm = SHA384.Create();
#pragma warning restore CA2000 // Dispose objects before losing scope
                        break;
                    case HashAlgorithmKind.SHA512:
#pragma warning disable CA2000 // Dispose objects before losing scope
                        hashAlgorithm = SHA512.Create();
#pragma warning restore CA2000 // Dispose objects before losing scope
                        break;
                    default:
                        throw new ArgumentException("Unsupported value", nameof(source));
                }
            }

            return ConvertResult.FromReference(hashAlgorithm);
        }
    }
}
