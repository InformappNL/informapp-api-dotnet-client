using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.DataContexts
{
    /// <summary>
    /// Data context abstraction
    /// </summary>
    public interface IDataContext
    {
        /// <summary>
        /// Open data context
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task Open(CancellationToken cancellationToken);

        /// <summary>
        /// Save changes to data context
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task SaveChanges(CancellationToken cancellationToken);

        /// <summary>
        /// Rollback pending changes
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task Rollback(CancellationToken cancellationToken);

        /// <summary>
        /// Data sources
        /// </summary>
        IList<DataSource> DataSources { get; }

        /// <summary>
        /// Integration imports
        /// </summary>
        IDictionary<Guid?, IntegrationImport> IntegrationImports { get; }

        /// <summary>
        /// Integration import queue
        /// </summary>
        IList<IntegrationImportQueueItem> IntegrationImportQueue { get; }
    }
}
