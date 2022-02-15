using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Jobs
{
    /// <summary>
    /// Generic job handler abstraction
    /// </summary>
    /// <typeparam name="T">The type of job</typeparam>
    public interface IJobHandler<T>
        where T : IJob
    {
        /// <summary>
        /// Execute job
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task</returns>
        Task Execute(CancellationToken cancellationToken);
    }
}
