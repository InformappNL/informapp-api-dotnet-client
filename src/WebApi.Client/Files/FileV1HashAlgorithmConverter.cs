﻿using ConnectedDevelopment.InformSystem.WebApi.Client.Converters;
using ConnectedDevelopment.InformSystem.WebApi.Client.Cryptography;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Files;
using System;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Files
{
    /// <summary>
    /// Implementation of <see cref="IConverter{TSource, TResult}"/> 
    /// to convert <see cref="FileV1HashAlgorithm"/> to <see cref="HashAlgorithmKind"/>
    /// </summary>
    public class FileV1HashAlgorithmConverter : IConverter<FileV1HashAlgorithm?, HashAlgorithmKind?>
    {
        /// <summary>
        /// Convert <see cref="FileV1HashAlgorithm"/> to <see cref="HashAlgorithmKind"/>
        /// </summary>
        /// <param name="source">The source value</param>
        /// <returns>The <see cref="ConvertResult{TResult}"/> containing the converted value</returns>
        public ConvertResult<HashAlgorithmKind?> Convert(FileV1HashAlgorithm? source)
        {
            HashAlgorithmKind? algorithm = null;

            if (source.HasValue == true)
            {
                switch (source)
                {
                    case FileV1HashAlgorithm.None:
                        algorithm = null;
                        break;
                    case FileV1HashAlgorithm.SHA256:
                        algorithm = HashAlgorithmKind.SHA256;
                        break;
                    case FileV1HashAlgorithm.SHA384:
                        algorithm = HashAlgorithmKind.SHA384;
                        break;
                    case FileV1HashAlgorithm.SHA512:
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
