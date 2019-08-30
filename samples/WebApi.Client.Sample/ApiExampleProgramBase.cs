using Autofac;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Examples;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample
{
    internal abstract class ApiExampleProgramBase
    {
        private readonly ILifetimeScope _container;

        protected ApiExampleProgramBase(
            ILifetimeScope container)
        {
            Argument.NotNull(container, nameof(container));

            _container = container;
        }

        protected Task Run<T>(CancellationToken cancellationToken)
            where T : class, IExample
        {
            return Run<T>(true, cancellationToken);
        }

        protected Task Run<T>(bool run, CancellationToken cancellationToken)
            where T : class, IExample
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (run == true)
            {
                var example = _container.Resolve<T>();

                return example.Run(cancellationToken);
            }

            return Task.CompletedTask;
        }
    }
}
