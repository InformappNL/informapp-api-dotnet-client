using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Jobs
{
    /// <summary>
    /// Queue integration import job
    /// </summary>
    public class QueueIntegrationImportJob : IJob
    {
        private readonly IJobHandler<QueueIntegrationImportJob> _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueIntegrationImportJob"/> class.
        /// </summary>
        /// <param name="handler">Job handler</param>
        public QueueIntegrationImportJob(
            IJobHandler<QueueIntegrationImportJob> handler)
        {
            Argument.NotNull(handler, nameof(handler));

            _handler = handler;
        }

        /// <summary>
        /// Execute job
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public Task Execute(CancellationToken cancellationToken)
        {
            return _handler.Execute(cancellationToken);
        }
    }
}
