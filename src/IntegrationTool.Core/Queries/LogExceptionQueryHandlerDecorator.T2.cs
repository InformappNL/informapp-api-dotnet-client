using Informapp.InformSystem.IntegrationTool.Core.Loggers;
using Informapp.InformSystem.WebApi.Client.Decorators;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Queries
{
    public class LogExceptionQueryHandlerDecorator<TQuery, TResult> : Decorator<IQueryHandler<TQuery, TResult>>,
        IQueryHandler<TQuery, TResult>

        where TQuery : class, IQuery<TResult>
        where TResult : class
    {
        private readonly IQueryHandler<TQuery, TResult> _handler;

        private readonly IApplicationLogger _logger;

        public LogExceptionQueryHandlerDecorator(
            IQueryHandler<TQuery, TResult> handler,
            IApplicationLogger logger) : base(handler)
        {
            Argument.NotNull(handler, nameof(handler));
            Argument.NotNull(logger, nameof(logger));

            _handler = handler;

            _logger = logger;
        }

        public Task<TResult> Handle(
            TQuery query,
            CancellationToken cancellationToken)
        {
            if (_logger.IsErrorEnabled)
            {
                return HandleWithErrorLogging(query, cancellationToken);
            }
            else
            {
                return _handler.Handle(query, cancellationToken);
            }
        }

        private async Task<TResult> HandleWithErrorLogging(
            TQuery query,
            CancellationToken cancellationToken)
        {
            try
            {
                var queryResult = await _handler
                    .Handle(query, cancellationToken)
                    .ConfigureAwait(Await.Default);

                return queryResult;
            }
            catch (Exception ex)
            {
                string queryName = typeof(TQuery).Name;

                _logger.ErrorFormat(
                    ex,
                    "Error executing query {0} :\r\n{1}",
                    queryName,
                    _logger.Serialize(query));

                throw;
            }
        }
    }
}
