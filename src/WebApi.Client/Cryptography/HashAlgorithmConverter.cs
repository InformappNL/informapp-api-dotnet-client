using Informapp.InformSystem.WebApi.Client.Converters;
using System;
using System.Security.Cryptography;

namespace Informapp.InformSystem.WebApi.Client.Cryptography
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
#pragma warning disable CA2000 // Dispose objects before losing scope
                switch (source)
                {
                    case HashAlgorithmKind.SHA256:
                        hashAlgorithm = SHA256.Create();
                        break;
                    case HashAlgorithmKind.SHA384:
                        hashAlgorithm = SHA384.Create();
                        break;
                    case HashAlgorithmKind.SHA512:
                        hashAlgorithm = SHA512.Create();
                        break;
                    default:
                        throw new ArgumentException("Unsupported value", nameof(source));
                }
#pragma warning restore CA2000 // Dispose objects before losing scope
            }

            return ConvertResult.FromReference(hashAlgorithm);
        }
    }
}
