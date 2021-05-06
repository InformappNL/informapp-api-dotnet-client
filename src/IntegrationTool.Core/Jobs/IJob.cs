using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Jobs
{
    /// <summary>
    /// Hangfire job interface
    /// </summary>
    public interface IJob
    {
        /// <summary>
        /// Execute job
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        Task Execute(CancellationToken cancellationToken);
    }
}
