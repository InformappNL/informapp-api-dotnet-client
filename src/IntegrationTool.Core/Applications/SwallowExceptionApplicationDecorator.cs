using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Applications
{
    /// <summary>
    /// Swallow exception application decorator
    /// </summary>
    public class SwallowExceptionApplicationDecorator : Decorator<IApplication>,
        IApplication
    {
        private readonly IApplication _application;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwallowExceptionApplicationDecorator"/> class.
        /// </summary>
        public SwallowExceptionApplicationDecorator(
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
            try
            {
                await _application
                    .Run(cancellationToken)
                    .ConfigureAwait(Await.Default);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception)
#pragma warning restore CA1031 // Do not catch general exception types
            {

            }
        }
    }
}
