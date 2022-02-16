using Informapp.InformSystem.IntegrationTool.Core.Loggers;
using Informapp.InformSystem.IntegrationTool.Core.Resources;
using Informapp.InformSystem.WebApi.Client.Decorators;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Applications
{
    /// <summary>
    /// Cancelled application decorator
    /// </summary>
    public class CancelledApplicationDecorator : Decorator<IApplication>,
        IApplication
    {
        private readonly IApplication _application;

        private readonly IApplicationLogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CancelledApplicationDecorator"/> class.
        /// </summary>
        public CancelledApplicationDecorator(
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
            try
            {
                await _application
                    .Run(cancellationToken)
                    .ConfigureAwait(Await.Default);
            }
            catch (OperationCanceledException)
            {
                if (_logger.IsErrorEnabled == true)
                {
                    _logger.Error(LogResource.OperationCancellled);
                }
            }
        }
    }
}
