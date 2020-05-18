using Autofac;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Examples;
using System;
using System.Linq;

namespace Informapp.InformSystem.WebApi.Client.Sample.Autofac.Registrations
{
    /// <summary>
    /// Register dependencies in Autofac
    /// </summary>
    internal class ExampleRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register dependencies in Autofac
        /// </summary>
        /// <param name="builder">The builder</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => x.IsClass == true)
                .Where(x => x.IsAbstract == false)
                .Where(x => typeof(IExample).IsAssignableFrom(x))
                .ToList();

            foreach (var type in types)
            {
                _ = builder.RegisterType(type)
                    .AsSelf()
                    .InstancePerLifetimeScope();
            }
        }
    }
}
