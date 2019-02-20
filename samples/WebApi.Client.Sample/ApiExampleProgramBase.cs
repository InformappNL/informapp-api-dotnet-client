using Autofac;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Examples;
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

        protected Task Run<T>()
            where T : class, IExample
        {
            return Run<T>(true);
        }

        protected Task Run<T>(bool run)
            where T : class, IExample
        {
            if (run == true)
            {
                var example = _container.Resolve<T>();

                return example.Run();
            }

            return Task.CompletedTask;
        }
    }
}
