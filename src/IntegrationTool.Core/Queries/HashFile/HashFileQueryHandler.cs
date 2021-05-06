using Informapp.InformSystem.WebApi.Client.Cryptography;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Queries.HashFile
{
    /// <summary>
    /// query handler for the hashing of the provided file
    /// </summary>
    public class HashFileQueryHandler : IQueryHandler<HashFileQuery, HashFileQueryResult>
    {
        private readonly IHasher _hasher;

        /// <summary>
        /// Initializes a new instance of the <see cref="HashFileQueryHandler"/> class
        /// </summary>
        /// <param name="hasher">Injected hasher</param>
        public HashFileQueryHandler(
            IHasher hasher)
        {
            Argument.NotNull(hasher, nameof(hasher));

            _hasher = hasher;
        }

        /// <summary>
        /// Handles the hashing of the file
        /// </summary>
        /// <param name="query">The query</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>Hash of the file</returns>
        public async Task<HashFileQueryResult> Handle(
            HashFileQuery query,
            CancellationToken cancellationToken)
        {
            Argument.NotNull(query, nameof(query));

            var queryResult = new HashFileQueryResult();

            _ = query.File.Seek(0, SeekOrigin.Begin);

            using (var hashAlgorithm = SHA512.Create())
            {
                var hash = await _hasher
                    .ComputeHashAsync(hashAlgorithm, query.File, cancellationToken)
                    .ConfigureAwait(Await.Default);

                queryResult.Hash = Convert.ToBase64String(hash);
            }

            _ = query.File.Seek(0, SeekOrigin.Begin);

            return queryResult;
        }
    }
}
