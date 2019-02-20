using Autofac;
using System;
using System.Collections.Generic;

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

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .AssignableTo(typeof(IAutofacRegistration))
                .As<IAutofacRegistration>()
                .InstancePerDependency();

            using (var container = builder.Build())
            {
                var registrations = container.Resolve<IEnumerable<IAutofacRegistration>>();

                return registrations;
            }
        }
    }
}
