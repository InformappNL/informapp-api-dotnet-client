using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.IntegrationImports
{
    /// <summary>
    /// Decorator class for <see cref="IUploadIntegrationImportCommandHandler"/> to log the exception if one was thrown
    /// </summary>
    public class ErrorUploadIntegrationImportDecorator : Decorator<IUploadIntegrationImportCommandHandler>,
        IUploadIntegrationImportCommandHandler
    {
        private readonly IUploadIntegrationImportCommandHandler _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorUploadIntegrationImportDecorator"/> class.
        /// </summary>
        /// <param name="handler">Injected command handler</param>
        public ErrorUploadIntegrationImportDecorator(
            IUploadIntegrationImportCommandHandler handler) : base(handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Set error in result
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public async Task<UploadIntegrationImportCommandResult> Handle(
            UploadIntegrationImportCommand command,
            CancellationToken cancellationToken)
        {
            UploadIntegrationImportCommandResult commandResult;

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
                commandResult = new UploadIntegrationImportCommandResult
                {
                    Success = false,
                    Message = "Error executing integration import",
                    Exception = ex,
                };
            }

            return commandResult;
        }
    }
}
