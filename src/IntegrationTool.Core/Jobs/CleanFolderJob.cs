using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Jobs
{
    /// <summary>
    /// Clean folder job
    /// </summary>
    public class CleanFolderJob : IJob
    {
        private readonly IJobHandler<CleanFolderJob> _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="CleanFolderJob"/> class.
        /// </summary>
        /// <param name="handler">Injected job handler</param>
        public CleanFolderJob(
            IJobHandler<CleanFolderJob> handler)
        {
            Argument.NotNull(handler, nameof(handler));

            _handler = handler;
        }

        /// <summary>
        /// Execute the clean folder job
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public Task Execute(CancellationToken cancellationToken)
        {
            return _handler.Execute(cancellationToken);
        }
    }
}
