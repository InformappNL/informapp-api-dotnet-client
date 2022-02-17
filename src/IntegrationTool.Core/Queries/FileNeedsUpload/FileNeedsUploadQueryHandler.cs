using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Configurations;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.DataContexts;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Queries.HashFile;
using ConnectedDevelopment.InformSystem.WebApi.Client.DateTimeProviders;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Queries.FileNeedsUpload
{
    /// <summary>
    /// Query handler for checking if a file needs to be uploaded
    /// </summary>
    public class FileNeedsUploadQueryHandler : IQueryHandler<FileNeedsUploadQuery, FileNeedsUploadQueryResult>
    {
        private readonly IOptions<DataSourceConfiguration> _configuration;

        private readonly IDataContext _dataContext;

        private readonly IDateTimeProvider _dateTimeProvider;

        private readonly IQueryHandler<HashFileQuery, HashFileQueryResult> _hashFileQueryHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileNeedsUploadQueryHandler"/> class
        /// </summary>
        /// <param name="configuration">Injected datasource configuration</param>
        /// <param name="dataContext">Injected data context</param>
        /// <param name="dateTimeProvider">Injected date time provider</param>
        /// <param name="hashFileQueryHandler">Injected hash file query handler</param>
        public FileNeedsUploadQueryHandler(
            IOptions<DataSourceConfiguration> configuration,
            IDataContext dataContext,
            IDateTimeProvider dateTimeProvider,
            IQueryHandler<HashFileQuery, HashFileQueryResult> hashFileQueryHandler)
        {
            Argument.NotNull(configuration, nameof(configuration));
            Argument.NotNull(dataContext, nameof(dataContext));
            Argument.NotNull(dateTimeProvider, nameof(dateTimeProvider));
            Argument.NotNull(hashFileQueryHandler, nameof(hashFileQueryHandler));

            _configuration = configuration;

            _dataContext = dataContext;

            _dateTimeProvider = dateTimeProvider;

            _hashFileQueryHandler = hashFileQueryHandler;
        }

        /// <summary>
        /// Handles the checking if the file needs to be uploaded
        /// </summary>
        /// <param name="query">The query</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public async Task<FileNeedsUploadQueryResult> Handle(
            FileNeedsUploadQuery query,
            CancellationToken cancellationToken)
        {
            Argument.NotNull(query, nameof(query));

            var queryResult = new FileNeedsUploadQueryResult();

            var file = _dataContext.DataSources
                .Where(x => string.Equals(query.Path, x.Path, StringComparison.OrdinalIgnoreCase) == true)
                .FirstOrDefault();

            var now = _dateTimeProvider.UtcNow;

            bool upload = false;

            var maxFileAge = _configuration.Value.MaxFileAge;

            var maxFileHashAge = _configuration.Value.MaxFileHashAge;

            if (file == null)
            {
                upload = true;
            }

            else if (file.UploadNeeded == true)
            {
                upload = true;
            }

            else if (file.Size.HasValue == false ||
                file.Size != query.Size)
            {
                upload = true;
            }

            else if (file.CreationTimeUtc.HasValue == false ||
                file.CreationTimeUtc != query.CreationTimeUtc)
            {
                upload = true;
            }

            else if (file.LastWriteTimeUtc.HasValue == false ||
                file.LastWriteTimeUtc != query.LastWriteTimeUtc)
            {
                upload = true;
            }

            else if (file.LastUploadDate.HasValue == false ||
                now - file.LastUploadDate >= maxFileAge)
            {
                upload = true;
            }

            else if (file.LastHashCheckDate.HasValue == false ||
                string.IsNullOrEmpty(file.Hash) == true ||
                now - file.LastHashCheckDate >= maxFileHashAge)
            {
                var hashFileQuery = new HashFileQuery
                {
                    File = query.File,
                };

                var hashFileQueryResult = await _hashFileQueryHandler
                    .Handle(hashFileQuery, cancellationToken)
                    .ConfigureAwait(Await.Default);

                if (string.Equals(file.Hash, hashFileQueryResult.Hash, StringComparison.Ordinal) == false)
                {
                    upload = true;
                }
            }

            queryResult.FileNeedsUpload = upload;

            return queryResult;
        }
    }
}
