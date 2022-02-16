using Informapp.InformSystem.IntegrationTool.Core.Collections;
using Informapp.InformSystem.IntegrationTool.Core.Configurations;
using Informapp.InformSystem.IntegrationTool.Core.Requires;
using Informapp.InformSystem.WebApi.Client.DateTimeProviders;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Queries.ListCleanFolderFile
{
    /// <summary>
    /// Query handler for making a list of files that will be cleaned up
    /// </summary>
    public class ListCleanFolderFileQueryHandler : IQueryHandler<ListCleanFolderFileQuery, ListCleanFolderFileQueryResult>
    {
        private readonly IOptions<CleanupFolderConfiguration> _configuration;

        private readonly IDirectoryInfoFactory _directoryInfoFactory;

        private readonly IDateTimeProvider _dateTimeProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListCleanFolderFileQueryHandler"/> class
        /// </summary>
        /// <param name="configuration">Injected cleanup folder configuration</param>
        /// <param name="directoryInfoFactory">Injected directory info factory</param>
        /// <param name="dateTimeProvider">Injected date time provider</param>
        public ListCleanFolderFileQueryHandler(
            IOptions<CleanupFolderConfiguration> configuration,
            IDirectoryInfoFactory directoryInfoFactory,
            IDateTimeProvider dateTimeProvider)
        {
            _configuration = configuration;

            _directoryInfoFactory = directoryInfoFactory;

            _dateTimeProvider = dateTimeProvider;
        }

        /// <summary>
        /// Handles creating the list
        /// </summary>
        /// <param name="query">The query</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>List of files</returns>
        public Task<ListCleanFolderFileQueryResult> Handle(
            ListCleanFolderFileQuery query,
            CancellationToken cancellationToken)
        {
            Argument.NotNull(query, nameof(query));

            var queryResult = new ListCleanFolderFileQueryResult();

            var configuration = _configuration.Value;

            Require.NotNull(configuration, nameof(configuration));

            if (configuration.Enabled == true)
            {
                var now = _dateTimeProvider.UtcNow.UtcDateTime;

                queryResult.Files = configuration.Folders
                    .Where(x => x.Enabled == true)
                    .Where(x => string.IsNullOrEmpty(x.Folder) == false)
                    .Where(x => x.Extensions.Count > 0)
                    .Where(x => x.MaxAgeInDays.HasValue && x.MaxAgeInDays.Value > 0)
                    .SelectMany(x => GetFiles(x, now));
                // No ToList()
            }

            return Task.FromResult(queryResult);
        }

        private IEnumerable<IFileInfo> GetFiles(CleanupFolderConfigurationFolder folder, DateTime now)
        {
            IEnumerable<IFileInfo> files;

            var directory = _directoryInfoFactory.FromDirectoryName(folder.Folder);

            if (directory.Exists)
            {
                var minDateTime = now.AddDays(folder.MaxAgeInDays.Value * -1);

                var extensions = folder.Extensions
                    .Where(x => string.IsNullOrEmpty(x) == false)
                    .Select(x => x[0] == '.' ? x : string.Concat(".", x))
                    .ToHashSet(StringComparer.OrdinalIgnoreCase);

                if (extensions.Count > 0)
                {
                    files = directory.EnumerateFiles()
                        .Where(x => string.IsNullOrEmpty(x.Extension) == false)
                        .Where(x => extensions.Contains(x.Extension))
                        .Where(x => x.Exists)
                        .Where(x => x.CreationTimeUtc <= minDateTime)
                        .Where(x => x.LastWriteTimeUtc <= minDateTime);
                    // No ToList()
                }
                else
                {
                    files = Enumerable.Empty<IFileInfo>();
                }
            }
            else
            {
                files = Enumerable.Empty<IFileInfo>();
            }

            return files;
        }
    }
}
