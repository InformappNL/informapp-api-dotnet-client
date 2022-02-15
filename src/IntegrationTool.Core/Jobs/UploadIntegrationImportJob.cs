using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Jobs
{
    /// <summary>
    /// Upload integration import job
    /// </summary>
    public class UploadIntegrationImportJob : IJob
    {
        private readonly IJobHandler<UploadIntegrationImportJob> _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadIntegrationImportJob"/> class.
        /// </summary>
        /// <param name="handler">Job handler</param>
        public UploadIntegrationImportJob(
            IJobHandler<UploadIntegrationImportJob> handler)
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
