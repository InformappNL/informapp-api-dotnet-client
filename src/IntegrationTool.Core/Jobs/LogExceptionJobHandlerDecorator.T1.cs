using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.IntegrationTool.Core.Loggers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Jobs
{
    /// <summary>
    /// Decorator class for <see cref="IJobHandler{T}"/> to log the error that was thrown in the hangfire job handler
    /// </summary>
    public class LogExceptionJobHandlerDecorator<T> : Decorator<IJobHandler<T>>,
        IJobHandler<T>

        where T : IJob
    {
        private readonly IJobHandler<T> _handler;

        private readonly IApplicationLogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogExceptionJobHandlerDecorator{T}"/> class.
        /// </summary>
        /// <param name="handler">Injected job handler</param>
        /// <param name="logger">Injected application logger</param>
        public LogExceptionJobHandlerDecorator(
            IJobHandler<T> handler,
            IApplicationLogger logger) : base(handler)
        {
            Argument.NotNull(handler, nameof(handler));
            Argument.NotNull(logger, nameof(logger));

            _handler = handler;

            _logger = logger;
        }

        /// <summary>
        /// Log error that was thrown in a hangfire job
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public Task Execute(CancellationToken cancellationToken)
        {
            if (_logger.IsErrorEnabled)
            {
                return ExecuteWithErrorLogging(cancellationToken);
            }
            else
            {
                return _handler.Execute(cancellationToken);
            }
        }

        private async Task ExecuteWithErrorLogging(CancellationToken cancellationToken)
        {
            try
            {
                await _handler
                    .Execute(cancellationToken)
                    .ConfigureAwait(Await.Default);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                _logger.ErrorFormat(ex, "Error executing {0}", typeof(T).Name);

                throw;
            }
        }
    }
}
