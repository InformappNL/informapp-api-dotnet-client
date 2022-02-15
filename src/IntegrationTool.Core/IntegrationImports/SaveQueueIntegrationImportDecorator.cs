using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.IntegrationTool.Core.DataContexts;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.IntegrationImports
{
    /// <summary>
    /// Save queue integration import decorator
    /// </summary>
    public class SaveQueueIntegrationImportDecorator : Decorator<IQueueIntegrationImportCommandHandler>,
        IQueueIntegrationImportCommandHandler
    {
        private readonly IQueueIntegrationImportCommandHandler _handler;

        private readonly IDataContext _dataContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveQueueIntegrationImportDecorator"/> class.
        /// </summary>
        public SaveQueueIntegrationImportDecorator(
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

            var commandResult = await _handler
                .Handle(command, cancellationToken)
                .ConfigureAwait(Await.Default);

            await _dataContext
                .SaveChanges(cancellationToken)
                .ConfigureAwait(Await.Default);

            return commandResult;
        }
    }
}
