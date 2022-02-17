using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Loggers;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Resources;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Applications
{
    /// <summary>
    /// Log application decorator
    /// </summary>
    public class LogApplicationDecorator : Decorator<IApplication>,
        IApplication
    {
        private readonly IApplication _application;

        private readonly IApplicationLogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogApplicationDecorator"/> class.
        /// </summary>
        public LogApplicationDecorator(
            IApplication application,
            IApplicationLogger logger) : base(application)
        {
            Argument.NotNull(application, nameof(application));
            Argument.NotNull(logger, nameof(logger));

            _application = application;

            _logger = logger;
        }

        /// <summary>
        /// Run the application
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task to run</returns>
        public async Task Run(CancellationToken cancellationToken)
        {
            bool isInfoEnabled = _logger.IsInfoEnabled;

            if (isInfoEnabled == true)
            {
                _logger.Info(LogResource.Starting);
            }

            await _application
                .Run(cancellationToken)
                .ConfigureAwait(Await.Default);

            if (isInfoEnabled == true)
            {
                _logger.Info(LogResource.Finished);
            }
        }
    }
}
