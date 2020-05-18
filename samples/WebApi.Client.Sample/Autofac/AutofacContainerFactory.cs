using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Informapp.InformSystem.WebApi.Client.Sample.Autofac
{
    /// <summary>
    /// Autofac container factory class
    /// </summary>
    internal static class AutofacContainerFactory
    {
        /// <summary>
        /// Create Autofac container
        /// </summary>
        /// <returns>The container</returns>
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

        /// <summary>
        /// Get collection of registrations to register with Autofac
        /// </summary>
        /// <returns>Collection of registrations</returns>
        private static IEnumerable<IAutofacRegistration> GetRegistrations()
        {
            var builder = new ContainerBuilder();

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
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

            using (var container = builder.Build())
            {
                var registrations = container.Resolve<IEnumerable<IAutofacRegistration>>();

                return registrations;
            }
        }
    }
}
