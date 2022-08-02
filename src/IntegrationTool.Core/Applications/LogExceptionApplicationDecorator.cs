using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Loggers;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Resources;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Applications
{
    /// <summary>
    /// Log exception application decorator
    /// </summary>
    public class LogExceptionApplicationDecorator : Decorator<IApplication>,
        IApplication
    {
        private readonly IApplication _application;

        private readonly IApplicationLogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogExceptionApplicationDecorator"/> class.
        /// </summary>
        public LogExceptionApplicationDecorator(
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
        public Task Run(CancellationToken cancellationToken)
        {
            if (_logger.IsFatalEnabled == true)
            {
                return RunWithErrorLogging(cancellationToken);
            }
            else
            {
                return _application.Run(cancellationToken);
            }
        }

        private async Task RunWithErrorLogging(CancellationToken cancellationToken)
        {
            try
            {
                await _application
                    .Run(cancellationToken)
                    .ConfigureAwait(Await.Default);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                _logger.Fatal(ex, LogResource.ApplicationError);

                throw;
            }
        }
    }
}
