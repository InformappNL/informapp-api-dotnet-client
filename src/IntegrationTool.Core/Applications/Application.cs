using Informapp.InformSystem.IntegrationTool.Core.Jobs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Applications
{
    /// <summary>
    /// Application
    /// </summary>
    public class Application : IApplication
    {
        private readonly IReadOnlyList<IJob> _jobs;

        /// <summary>
        /// Initializes a new instance of the <see cref="Application"/> class.
        /// </summary>
        public Application(
            IReadOnlyList<IJob> jobs)
        {
            Argument.NotNullOrEmpty(jobs, nameof(jobs));

            _jobs = jobs;
        }

        /// <summary>
        /// Run the application
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task to run</returns>
        public async Task Run(CancellationToken cancellationToken)
        {
            foreach (var job in _jobs)
            {
                await job
                    .Execute(cancellationToken)
                    .ConfigureAwait(Await.Default);
            }
        }
    }
}
