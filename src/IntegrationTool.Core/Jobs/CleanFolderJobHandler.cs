using Informapp.InformSystem.IntegrationTool.Core.Queries;
using Informapp.InformSystem.IntegrationTool.Core.Queries.ListCleanFolderFile;
using System;
using System.IO;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Jobs
{
    /// <summary>
    /// Clean folder hangfire job handler
    /// </summary>
    public class CleanFolderJobHandler : IJobHandler<CleanFolderJob>
    {
        private readonly IQueryHandler<ListCleanFolderFileQuery, ListCleanFolderFileQueryResult> _queryHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="CleanFolderJobHandler"/> class.
        /// </summary>
        /// <param name="queryHandler">Injected query handler</param>
        public CleanFolderJobHandler(
            IQueryHandler<ListCleanFolderFileQuery, ListCleanFolderFileQueryResult> queryHandler)
        {
            _queryHandler = queryHandler;
        }

        /// <summary>
        /// Execute clean folder job
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public async Task Execute(CancellationToken cancellationToken)
        {
            var query = new ListCleanFolderFileQuery();

            var queryResult = await _queryHandler
                .Handle(query, cancellationToken)
                .ConfigureAwait(Await.Default);

            if (queryResult.Files != null)
            {
                foreach (var file in queryResult.Files)
                {
                    try
                    {
                        file.Delete();
                    }
                    catch (IOException) { }
                    catch (SecurityException) { }
                    catch (UnauthorizedAccessException) { }
                }
            }
        }
    }
}
