using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.IntegrationTool.Core.Loggers;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Jobs
{
    /// <summary>
    /// Decorator class for <see cref="IJobHandler{T}"/> to log the execution of a job
    /// </summary>
    public class LogJobHandlerDecorator<T> : Decorator<IJobHandler<T>>,
        IJobHandler<T>

        where T : IJob
    {
        private readonly IJobHandler<T> _handler;

        private readonly IApplicationLogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogJobHandlerDecorator{T}"/> class.
        /// </summary>
        /// <param name="handler">Injected job handler</param>
        /// <param name="logger">Injected application logger</param>
        public LogJobHandlerDecorator(
            IJobHandler<T> handler,
            IApplicationLogger logger) : base(handler)
        {
            Argument.NotNull(handler, nameof(handler));
            Argument.NotNull(logger, nameof(logger));

            _handler = handler;

            _logger = logger;
        }

        /// <summary>
        /// Execute log
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public async Task Execute(CancellationToken cancellationToken)
        {
            bool isInfoEnabled = _logger.IsInfoEnabled;

            if (isInfoEnabled == true)
            {
                _logger.InfoFormat("Executing {0}", typeof(T).Name);
            }

            await _handler
                .Execute(cancellationToken)
                .ConfigureAwait(Await.Default);

            if (isInfoEnabled == true)
            {
                _logger.InfoFormat("Executed {0}", typeof(T).Name);
            }
        }
    }
}
