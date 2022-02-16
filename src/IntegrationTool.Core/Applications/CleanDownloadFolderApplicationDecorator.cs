using Informapp.InformSystem.IntegrationTool.Core.Commands;
using Informapp.InformSystem.IntegrationTool.Core.Commands.CleanupDownloadFolder;
using Informapp.InformSystem.IntegrationTool.Core.Configurations;
using Informapp.InformSystem.IntegrationTool.Core.Requires;
using Informapp.InformSystem.WebApi.Client.Decorators;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Applications
{
    /// <summary>
    /// Clean download folder application decorator
    /// </summary>
    public class CleanDownloadFolderApplicationDecorator : Decorator<IApplication>,
        IApplication
    {
        private readonly IApplication _application;

        private readonly IOptions<IntegrationExportConfiguration> _integrationConfiguration;

        private readonly ICommandHandler<CleanupDownloadFolderCommand, CleanupDownloadFolderCommandResult> _cleanupCommandHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="CleanDownloadFolderApplicationDecorator"/> class.
        /// </summary>
        public CleanDownloadFolderApplicationDecorator(
            IApplication application,
            IOptions<IntegrationExportConfiguration> integrationConfiguration,
            ICommandHandler<CleanupDownloadFolderCommand, CleanupDownloadFolderCommandResult> cleanupCommandHandler) : base(application)
        {
            Argument.NotNull(application, nameof(application));
            Argument.NotNull(integrationConfiguration, nameof(integrationConfiguration));
            Argument.NotNull(cleanupCommandHandler, nameof(cleanupCommandHandler));

            _application = application;

            _integrationConfiguration = integrationConfiguration;

            _cleanupCommandHandler = cleanupCommandHandler;
        }

        /// <summary>
        /// Run the application
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task to run</returns>
        public Task Run(CancellationToken cancellationToken)
        {
            var configuration = _integrationConfiguration.Value;

            Require.NotNull(configuration, nameof(configuration));

            if (configuration.Enabled == true &&
                configuration.CleanDownloadFolder == true)
            {
                return RunWithCleanup(cancellationToken);
            }
            else
            {
                return _application.Run(cancellationToken);
            }
        }

        private async Task RunWithCleanup(CancellationToken cancellationToken)
        {
            await Cleanup(cancellationToken)
                .ConfigureAwait(Await.Default);

            await _application.Run(cancellationToken)
                .ConfigureAwait(Await.Default);

            await Cleanup(cancellationToken)
                .ConfigureAwait(Await.Default);
        }

        private Task Cleanup(CancellationToken cancellationToken)
        {
            var cleanupCommand = new CleanupDownloadFolderCommand();

            return _cleanupCommandHandler.Handle(cleanupCommand, cancellationToken);
        }
    }
}
