using Informapp.InformSystem.WebApi.Client.Decorators;
using System.IO.Abstractions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Integrations
{
    /// <summary>
    /// Decorator class for <see cref="IDownloadIntegrationExportCommandHandler"/> to sanitise the filename
    /// </summary>
    public class SanitiseFileNameDownloadIntegrationExportCommandHandlerDecorator : Decorator<IDownloadIntegrationExportCommandHandler>,
        IDownloadIntegrationExportCommandHandler
    {
        private readonly IDownloadIntegrationExportCommandHandler _handler;

        private readonly IPath _path;

        /// <summary>
        /// Initializes a new instance of the <see cref="SanitiseFileNameDownloadIntegrationExportCommandHandlerDecorator"/> class.
        /// </summary>
        /// <param name="handler">Injected command handler</param>
        /// <param name="path">Injected path</param>
        public SanitiseFileNameDownloadIntegrationExportCommandHandlerDecorator(
            IDownloadIntegrationExportCommandHandler handler,
            IPath path) : base(handler)
        {
            Argument.NotNull(handler, nameof(handler));
            Argument.NotNull(path, nameof(path));

            _handler = handler;

            _path = path;
        }

        /// <summary>
        /// Sanitise filename and execute command
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public Task<DownloadIntegrationExportCommandResult> Handle(
            DownloadIntegrationExportCommand command,
            CancellationToken cancellationToken)
        {
            Argument.NotNull(command, nameof(command));

            if (string.IsNullOrEmpty(command.FileName) == false)
            {
                var builder = new StringBuilder(command.FileName);

                var invalidChars = _path.GetInvalidFileNameChars();

                foreach (var invalidChar in invalidChars)
                {
                    builder = builder.Replace(invalidChar, '_');
                }

                string sanitisedFileName = builder.ToString();

                command.FileName = sanitisedFileName;
            }

            return _handler.Handle(command, cancellationToken);
        }
    }
}
