using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Jobs
{
    /// <summary>
    /// Generic hangfire job handler interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IJobHandler<T>
        where T : IJob
    {
        /// <summary>
        /// Execute job handler
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        Task Execute(CancellationToken cancellationToken);
    }
}
