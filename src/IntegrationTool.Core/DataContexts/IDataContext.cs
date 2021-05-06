using Informapp.InformSystem.IntegrationTool.Core.IO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.DataContexts
{
    /// <summary>
    /// Data context interface
    /// </summary>
    public interface IDataContext
    {
        /// <summary>
        /// Open data context
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>Data context file</returns>
        Task Open(CancellationToken cancellationToken);

        /// <summary>
        /// Save changes to data context file
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task SaveChanges(CancellationToken cancellationToken);

        /// <summary>
        /// List of data context files
        /// </summary>
        IList<FileModel> Files { get; }
    }
}
