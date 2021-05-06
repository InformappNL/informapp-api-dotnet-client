using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.IntegrationTool.Core.Loggers;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Uploaders
{
    /// <summary>
    /// Decorator class for <see cref="IUploader{TCommand}"/> to log upload has started
    /// </summary>
    /// <typeparam name="TCommand">Type of command</typeparam>
    public class LogUploaderDecorator<TCommand> : Decorator<IUploader<TCommand>>,
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
        public LogUploaderDecorator(
            IUploader<TCommand> uploader,
            IApplicationLogger logger) : base(uploader)
        {
            Argument.NotNull(uploader, nameof(uploader));
            Argument.NotNull(logger, nameof(logger));

            _uploader = uploader;

            _logger = logger;
        }

        /// <summary>
        /// Logs upload has started and continues with uploading
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>Upload continues</returns>
        public Task<IUploadResult> Upload(TCommand command, CancellationToken cancellationToken)
        {
            Argument.NotNull(command, nameof(command));

            if (_logger.IsInfoEnabled == true)
            {
                _logger.InfoFormat("Uploading {0}", command.Path);
            }

            return _uploader.Upload(command, cancellationToken);
        }
    }
}
