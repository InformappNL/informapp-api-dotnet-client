using Autofac;
using Informapp.InformSystem.IntegrationTool.App.Autofac.Registrations;
using System.Collections.Generic;
using System.Linq;

namespace Informapp.InformSystem.IntegrationTool.App.Autofac
{
    /// <summary>
    /// Factory for Autofac container
    /// </summary>
    public static class AutofacContainerFactory
    {
        /// <summary>
        /// Create Autofac container
        /// </summary>
        /// <returns>The Autofac container</returns>
        public static IContainer Create()
        {
            var builder = new ContainerBuilder();

            var registrations = GetRegistrations();

            foreach (var registration in registrations)
            {
                registration.Register(builder);
            }

            var container = builder.Build();

            return container;
        }

        private static IEnumerable<IAutofacRegistration> GetRegistrations()
        {
            var builder = new ContainerBuilder();

            var registrations = new IAutofacRegistration[]
            {
                new AssemblyProviderRegistration(),
            };

            foreach (var registration in registrations)
            {
                registration.Register(builder);
            }

            var types = typeof(IntegrationToolAppProject).Assembly
                .GetTypes()
                .Where(x => x.IsClass == true)
                .Where(x => x.IsAbstract == false)
                .Where(x => typeof(IAutofacRegistration).IsAssignableFrom(x))
                .ToList();

            foreach (var type in types)
            {
                _ = builder.RegisterType(type)
                    .As<IAutofacRegistration>()
                    .InstancePerLifetimeScope();
            }

#pragma warning disable IDE0063 // Use simple 'using' statement
            using (var container = builder.Build())
#pragma warning restore IDE0063 // Use simple 'using' statement
            {
                return container.Resolve<IList<IAutofacRegistration>>();
            }
        }
    }
}
