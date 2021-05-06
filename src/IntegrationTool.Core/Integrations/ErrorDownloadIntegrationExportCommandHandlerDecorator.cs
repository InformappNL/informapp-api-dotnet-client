using Informapp.InformSystem.WebApi.Client.Decorators;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Integrations
{
    /// <summary>
    /// Decorator class for <see cref="IDownloadIntegrationExportCommandHandler"/> to log the exception if one was thrown
    /// </summary>
    public class ErrorDownloadIntegrationExportCommandHandlerDecorator : Decorator<IDownloadIntegrationExportCommandHandler>,
        IDownloadIntegrationExportCommandHandler
    {
        private readonly IDownloadIntegrationExportCommandHandler _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorDownloadIntegrationExportCommandHandlerDecorator"/> class.
        /// </summary>
        /// <param name="handler">Injected command handler</param>
        public ErrorDownloadIntegrationExportCommandHandlerDecorator(
            IDownloadIntegrationExportCommandHandler handler) : base(handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Set error in result
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public async Task<DownloadIntegrationExportCommandResult> Handle(
            DownloadIntegrationExportCommand command,
            CancellationToken cancellationToken)
        {
            DownloadIntegrationExportCommandResult commandResult;

            try
            {
                commandResult = await _handler
                    .Handle(command, cancellationToken)
                    .ConfigureAwait(Await.Default);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                commandResult = new DownloadIntegrationExportCommandResult
                {
                    Success = false,
                    Message = "Error executing integration export",
                    Exception = ex,
                };
            }

            return commandResult;
        }
    }
}
