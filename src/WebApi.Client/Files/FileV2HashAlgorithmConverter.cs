﻿using Informapp.InformSystem.WebApi.Client.Converters;
using Informapp.InformSystem.WebApi.Client.Cryptography;
using Informapp.InformSystem.WebApi.Models.Version2.Files;
using System;

namespace Informapp.InformSystem.WebApi.Client.Files
{
    /// <summary>
    /// Implementation of <see cref="IConverter{TSource, TResult}"/> 
    /// to convert <see cref="FileV2HashAlgorithm"/> to <see cref="HashAlgorithmKind"/>
    /// </summary>
    public class FileV2HashAlgorithmConverter : IConverter<FileV2HashAlgorithm?, HashAlgorithmKind?>
    {
        /// <summary>
        /// Convert <see cref="FileV2HashAlgorithm"/> to <see cref="HashAlgorithmKind"/>
        /// </summary>
        /// <param name="source">The source value</param>
        /// <returns>The <see cref="ConvertResult{TResult}"/> containing the converted value</returns>
        public ConvertResult<HashAlgorithmKind?> Convert(FileV2HashAlgorithm? source)
        {
            HashAlgorithmKind? algorithm = null;

            if (source.HasValue == true)
            {
                switch (source)
                {
                    case FileV2HashAlgorithm.None:
                        algorithm = null;
                        break;
                    case FileV2HashAlgorithm.MD5:
                        algorithm = HashAlgorithmKind.MD5;
                        break;
                    case FileV2HashAlgorithm.RIPEMD160:
                        algorithm = HashAlgorithmKind.RIPEMD160;
                        break;
                    case FileV2HashAlgorithm.SHA1:
                        algorithm = HashAlgorithmKind.SHA1;
                        break;
                    case FileV2HashAlgorithm.SHA256:
                        algorithm = HashAlgorithmKind.SHA256;
                        break;
                    case FileV2HashAlgorithm.SHA384:
                        algorithm = HashAlgorithmKind.SHA384;
                        break;
                    case FileV2HashAlgorithm.SHA512:
                        algorithm = HashAlgorithmKind.SHA512;
                        break;
                    default:
                        throw new ArgumentException("Unexpected value", nameof(source));
                }
            }

            return ConvertResult.FromNullable(algorithm);
        }
    }
}
