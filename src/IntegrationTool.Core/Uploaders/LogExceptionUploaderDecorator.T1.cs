using Informapp.InformSystem.IntegrationTool.Core.Loggers;
using Informapp.InformSystem.WebApi.Client.Decorators;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Uploaders
{
    public class LogExceptionUploaderDecorator<TCommand> : Decorator<IUploader<TCommand>>,
        IUploader<TCommand>

        where TCommand : class, IUploadCommand
    {
        private readonly IUploader<TCommand> _uploader;

        private readonly IApplicationLogger _logger;

        public LogExceptionUploaderDecorator(
            IUploader<TCommand> uploader,
            IApplicationLogger logger) : base(uploader)
        {
            Argument.NotNull(uploader, nameof(uploader));
            Argument.NotNull(logger, nameof(logger));

            _uploader = uploader;

            _logger = logger;
        }

        public Task<IUploadResult> Upload(
            TCommand command,
            CancellationToken cancellationToken)
        {
            if (_logger.IsErrorEnabled)
            {
                return UploadWithErrorLogging(command, cancellationToken);
            }
            else
            {
                return _uploader.Upload(command, cancellationToken);
            }
        }

        private async Task<IUploadResult> UploadWithErrorLogging(
            TCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var commandResult = await _uploader
                    .Upload(command, cancellationToken)
                    .ConfigureAwait(Await.Default);

                return commandResult;
            }
            catch (Exception ex)
            {
                string commandName = typeof(TCommand).Name;

                _logger.ErrorFormat(
                    ex,
                    "Error executing command {0} :\r\n{1}",
                    commandName,
                    _logger.Serialize(command));

                throw;
            }
        }
    }
}
