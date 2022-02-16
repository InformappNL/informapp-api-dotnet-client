using Informapp.InformSystem.IntegrationTool.Core.DataContexts;
using Informapp.InformSystem.WebApi.Client.Decorators;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Applications
{
    /// <summary>
    /// Data context application decorator
    /// </summary>
    public class DataContextApplicationDecorator : Decorator<IApplication>,
        IApplication
    {
        private readonly IApplication _application;

        private readonly IDataContext _dataContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataContextApplicationDecorator"/> class.
        /// </summary>
        public DataContextApplicationDecorator(
            IApplication application,
            IDataContext dataContext) : base(application)
        {
            Argument.NotNull(application, nameof(application));
            Argument.NotNull(dataContext, nameof(dataContext));

            _application = application;

            _dataContext = dataContext;
        }

        /// <summary>
        /// Run the application
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task to run</returns>
        public async Task Run(CancellationToken cancellationToken)
        {
            await _dataContext
                .Open(cancellationToken)
                .ConfigureAwait(Await.Default);

            await _application
                .Run(cancellationToken)
                .ConfigureAwait(Await.Default);

            await _dataContext
                .SaveChanges(cancellationToken)
                .ConfigureAwait(Await.Default);
        }
    }
}
