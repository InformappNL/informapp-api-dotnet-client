using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Loggers;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Queries
{
    /// <summary>
    /// Debug query handler decorator
    /// </summary>
    /// <typeparam name="TQuery">The type of query</typeparam>
    /// <typeparam name="TResult">The type of result</typeparam>
    public class DebugQueryHandlerDecorator<TQuery, TResult> : Decorator<IQueryHandler<TQuery, TResult>>,
        IQueryHandler<TQuery, TResult>

        where TQuery : class, IQuery<TResult>
        where TResult : class
    {
        private readonly IQueryHandler<TQuery, TResult> _handler;

        private readonly IApplicationLogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DebugQueryHandlerDecorator{TQuery, TResult}"/> class
        /// </summary>
        public DebugQueryHandlerDecorator(
            IQueryHandler<TQuery, TResult> handler,
            IApplicationLogger logger) : base(handler)
        {
            Argument.NotNull(handler, nameof(handler));
            Argument.NotNull(logger, nameof(logger));

            _handler = handler;

            _logger = logger;
        }

        /// <inheritdoc/>
        public Task<TResult> Handle(TQuery query, CancellationToken cancellationToken)
        {
            if (_logger.IsDebugEnabled)
            {
                return HandleWithDebug(query, cancellationToken);
            }
            else
            {
                return _handler.Handle(query, cancellationToken);
            }
        }

        private async Task<TResult> HandleWithDebug(TQuery query, CancellationToken cancellationToken)
        {
            string queryName = typeof(TQuery).Name;

            _logger.DebugFormat(
                "Executing query {0} :\r\n{1}",
                queryName,
                _logger.Serialize(query));

            var commandResult = await _handler
                .Handle(query, cancellationToken)
                .ConfigureAwait(Await.Default);

            _logger.DebugFormat(
                "Executed query {0} :\r\n{1}",
                queryName,
                _logger.Serialize(commandResult));

            return commandResult;
        }
    }
}
