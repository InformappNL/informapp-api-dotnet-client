﻿using Autofac;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Queries;
using ConnectedDevelopment.InformSystem.WebApi.Client.Assemblies;
using System.Linq;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register query handlers in Autofac
    /// </summary>
    public class QueryHandlerRegistration : IAutofacRegistration
    {
        private readonly IAssemblyProvider _assemblyProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryHandlerRegistration"/> class.
        /// </summary>
        public QueryHandlerRegistration(
            IAssemblyProvider assemblyProvider)
        {
            Argument.NotNull(assemblyProvider, nameof(assemblyProvider));

            _assemblyProvider = assemblyProvider;
        }

        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            var serviceType = typeof(IQueryHandler<,>);

            var types = _assemblyProvider.GetLocalAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => x.IsClass == true)
                .Where(x => x.IsGenericType == false)
                .SelectMany(x => x.GetInterfaces(), (i, s) => (Implementor: i, Service: s))
                .Where(x => x.Service.IsGenericType == true)
                .Where(x => x.Service.ContainsGenericParameters == false)
                .Where(x => x.Service.GetGenericTypeDefinition() == serviceType)
                .ToList();

            foreach (var (implementor, service) in types)
            {
                _ = builder.RegisterType(implementor)
                    .As(service)
                    .InstancePerLifetimeScope();
            }

            var decorators = new[]
            {
                typeof(ValidateQueryHandlerDecorator<,>),
                typeof(LogExceptionQueryHandlerDecorator<,>),
                typeof(DebugQueryHandlerDecorator<,>),
            };

            foreach (var decorator in decorators)
            {
                builder.RegisterGenericDecorator(decorator, serviceType);
            }
        }
    }
}
