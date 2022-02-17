using Autofac;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Examples;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Requires;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample
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

        protected Task Execute<T>(CancellationToken cancellationToken)
            where T : class, IExample
        {
            return Execute<T>(execute: true, cancellationToken);
        }

        protected Task Execute<T>(bool execute, CancellationToken cancellationToken)
            where T : class, IExample
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (execute == true)
            {
                var example = _container.Resolve<T>();

                Require.NotNull(example, nameof(example));

                return example.Execute(cancellationToken);
            }

            return Task.CompletedTask;
        }

        protected ExampleExecutionModel Create<T>()
            where T : class, IExample
        {
            return Create<T>(true);
        }

        protected ExampleExecutionModel Create<T>(bool execute)
            where T : class, IExample
        {
            var model = new ExampleExecutionModel
            {
                Execute = execute,
            };

            if (execute == true)
            {
                model.Task = Execute<T>;
            }

            return model;
        }

        protected class ExampleExecutionModel
        {
            public bool Execute { get; set; }

            public Func<CancellationToken, Task> Task { get; set; }
        }
    }
}
