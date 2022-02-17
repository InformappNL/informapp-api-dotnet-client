using Autofac;
using ConnectedDevelopment.InformSystem.IntegrationTool.App.Autofac;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Applications;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.App
{
    /// <summary>
    /// Console application
    /// </summary>
    public class ConsoleApplication : IApplication
    {
        /// <summary>
        /// Run the application
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The Task to run</returns>
        public async Task Run(CancellationToken cancellationToken)
        {
#pragma warning disable IDE0063 // Use simple 'using' statement
            using (var container = AutofacContainerFactory.Create())
            using (var scope = container.BeginLifetimeScope())
#pragma warning restore IDE0063 // Use simple 'using' statement
            {
                var application = scope.Resolve<IApplication>();

                await application
                    .Run(cancellationToken)
                    .ConfigureAwait(Await.Default);
            }
        }
    }
}
