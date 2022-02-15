using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.IntegrationTool.Core.DataContexts;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.IntegrationImports
{
    public class SaveQueueIntegrationImportDecorator : Decorator<IQueueIntegrationImportCommandHandler>,
        IQueueIntegrationImportCommandHandler
    {
        private readonly IQueueIntegrationImportCommandHandler _handler;

        private readonly IDataContext _dataContext;

        public SaveQueueIntegrationImportDecorator(
            IQueueIntegrationImportCommandHandler handler,
            IDataContext dataContext) : base(handler)
        {
            _handler = handler;

            _dataContext = dataContext;
        }

        /// <inheritdoc/>
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
