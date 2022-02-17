using ConnectedDevelopment.InformSystem.IntegrationTool.Core.DataContexts;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.IntegrationImports
{
    /// <summary>
    /// Rollback queue integration import decorator
    /// </summary>
    public class RollbackQueueIntegrationImportDecorator : Decorator<IQueueIntegrationImportCommandHandler>,
        IQueueIntegrationImportCommandHandler
    {
        private readonly IQueueIntegrationImportCommandHandler _handler;

        private readonly IDataContext _dataContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="RollbackQueueIntegrationImportDecorator"/> class.
        /// </summary>
        public RollbackQueueIntegrationImportDecorator(
            IQueueIntegrationImportCommandHandler handler,
            IDataContext dataContext) : base(handler)
        {
            _handler = handler;

            _dataContext = dataContext;
        }

        /// <summary>
        /// Handle the command
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The command result</returns>
        public async Task<QueueIntegrationImportCommandResult> Handle(
            QueueIntegrationImportCommand command,
            CancellationToken cancellationToken)
        {
            Argument.NotNull(command, nameof(command));

            try
            {
                var commandResult = await _handler
                    .Handle(command, cancellationToken)
                    .ConfigureAwait(Await.Default);

                return commandResult;
            }
            catch (Exception)
            {
                await _dataContext
                    .Rollback(cancellationToken)
                    .ConfigureAwait(Await.Default);

                throw;
            }
        }
    }
}
