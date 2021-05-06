using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Jobs
{
    /// <summary>
    /// Upload datasource file hangfire job
    /// </summary>
    public class UploadDataSourceFileJob : IJob
    {
        private readonly IJobHandler<UploadDataSourceFileJob> _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadDataSourceFileJob"/> class.
        /// </summary>
        /// <param name="handler">Injected hangfire job handler</param>
        public UploadDataSourceFileJob(
            IJobHandler<UploadDataSourceFileJob> handler)
        {
            Argument.NotNull(handler, nameof(handler));

            _handler = handler;
        }

        /// <summary>
        /// Execute upload datasource file hangfire job
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public Task Execute(CancellationToken cancellationToken)
        {
            return _handler.Execute(cancellationToken);
        }
    }
}
