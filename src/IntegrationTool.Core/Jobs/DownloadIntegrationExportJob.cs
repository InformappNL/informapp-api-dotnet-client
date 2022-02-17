using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Jobs
{
    /// <summary>
    /// Download integration export hangfire job
    /// </summary>
    public class DownloadIntegrationExportJob : IJob
    {
        private readonly IJobHandler<DownloadIntegrationExportJob> _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadIntegrationExportJob"/> class.
        /// </summary>
        /// <param name="handler">Injected job handler</param>
        public DownloadIntegrationExportJob(
            IJobHandler<DownloadIntegrationExportJob> handler)
        {
            Argument.NotNull(handler, nameof(handler));

            _handler = handler;
        }

        /// <summary>
        /// Execute download integration export job
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public Task Execute(CancellationToken cancellationToken)
        {
            return _handler.Execute(cancellationToken);
        }
    }
}
