using Informapp.InformSystem.IntegrationTool.Core.Loggers;
using Informapp.InformSystem.WebApi.Client.Decorators;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Uploaders
{
    /// <summary>
    /// Decorator class for <see cref="IUploader{TCommand}"/> to log debug information
    /// </summary>
    /// <typeparam name="TCommand">Type of command</typeparam>
    public class DebugUploaderDecorator<TCommand> : Decorator<IUploader<TCommand>>,
        IUploader<TCommand>

        where TCommand : class, IUploadCommand
    {
        private readonly IUploader<TCommand> _uploader;

        private readonly IApplicationLogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogUploaderDecorator{TCommand}"/> class
        /// </summary>
        /// <param name="uploader">Injected uploader</param>
        /// <param name="logger">Injected application logger</param>
        public DebugUploaderDecorator(
            IUploader<TCommand> uploader,
            IApplicationLogger logger) : base(uploader)
        {
            Argument.NotNull(uploader, nameof(uploader));
            Argument.NotNull(logger, nameof(logger));

            _uploader = uploader;

            _logger = logger;
        }

        /// <summary>
        /// Log debug information
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>Upload continues</returns>
        public Task<IUploadResult> Upload(
            TCommand command,
            CancellationToken cancellationToken)
        {
            if (_logger.IsDebugEnabled)
            {
                return UploadWithDebug(command, cancellationToken);
            }
            else
            {
                return _uploader.Upload(command, cancellationToken);
            }
        }

        private async Task<IUploadResult> UploadWithDebug(
            TCommand command,
            CancellationToken cancellationToken)
        {
            string commandName = typeof(TCommand).Name;

            _logger.DebugFormat(
                "Executing upload command {0} :\r\n{1}",
                commandName,
                _logger.Serialize(command));

            var commandResult = await _uploader
                .Upload(command, cancellationToken)
                .ConfigureAwait(Await.Default);

            _logger.DebugFormat(
                "Executed upload command {0} :\r\n{1}",
                commandName,
                _logger.Serialize(commandResult));

            return commandResult;
        }
    }
}
