using Informapp.InformSystem.WebApi.Client.Decorators;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Applications
{
    public class SwallowExceptionApplicationDecorator : Decorator<IApplication>,
        IApplication
    {
        private readonly IApplication _application;

        public SwallowExceptionApplicationDecorator(
            IApplication application) : base(application)
        {
            Argument.NotNull(application, nameof(application));

            _application = application;
        }

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
