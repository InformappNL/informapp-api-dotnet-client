using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using log4net;
using log4net.Config;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Applications
{
    /// <summary>
    /// Log4net application decorator
    /// </summary>
    public class Log4NetApplicationDecorator : Decorator<IApplication>,
        IApplication
    {
        private readonly IApplication _application;

        /// <summary>
        /// Initializes a new instance of the <see cref="Log4NetApplicationDecorator"/> class.
        /// </summary>
        public Log4NetApplicationDecorator(
            IApplication application) : base(application)
        {
            Argument.NotNull(application, nameof(application));

            _application = application;
        }

        /// <summary>
        /// Run the application
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task to run</returns>
        public async Task Run(CancellationToken cancellationToken)
        {
            _ = XmlConfigurator.Configure();

            await _application
                .Run(cancellationToken)
                .ConfigureAwait(Await.Default);

            _ = LogManager.Flush(1000);

            LogManager.Shutdown();
        }
    }
}
