using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.IntegrationTool.Core.Configurations;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.IntegrationExports
{
    /// <summary>
    /// Decorator class for <see cref="IDownloadIntegrationExportCommandHandler"/> to set configuration and accept download
    /// </summary>
    public class ConfigurationDownloadIntegrationExportCommandHandlerDecorator : Decorator<IDownloadIntegrationExportCommandHandler>,
        IDownloadIntegrationExportCommandHandler
    {
        private readonly IDownloadIntegrationExportCommandHandler _handler;

        private readonly IOptions<IntegrationExportConfiguration> _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationDownloadIntegrationExportCommandHandlerDecorator"/> class
        /// </summary>
        /// <param name="handler">The instance to decorate</param>
        /// <param name="configuration">The configuration instance to decorate</param>
        public ConfigurationDownloadIntegrationExportCommandHandlerDecorator(
            IDownloadIntegrationExportCommandHandler handler,
            IOptions<IntegrationExportConfiguration> configuration) : base(handler)
        {
            Argument.NotNull(handler, nameof(handler));
            Argument.NotNull(configuration, nameof(configuration));

            _handler = handler;

            _configuration = configuration;
        }

        /// <summary>
        /// Set configuration and accept download
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public Task<DownloadIntegrationExportCommandResult> Handle(
            DownloadIntegrationExportCommand command,
            CancellationToken cancellationToken)
        {
            Argument.NotNull(command, nameof(command));

            var configuration = GetConfiguration(command);

            if (configuration != null)
            {
                command.Configuration = configuration;

                command.Accept = configuration.Enabled == true;
            }
            else
            {
                command.Accept = false;
            }

            return _handler.Handle(command, cancellationToken);
        }

        private IIntegrationConfiguration GetConfiguration(
            DownloadIntegrationExportCommand command)
        {
            IIntegrationConfiguration configuration;

            configuration = _configuration.Value
                .IntegrationExports
                .Where(x => x.IntegrationId == command.IntegrationId)
                .SingleOrDefault();

            if (configuration == null)
            {
                configuration = _configuration.Value.Default;
            }

            return configuration;
        }
    }
}
