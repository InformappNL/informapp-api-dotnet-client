﻿using Autofac;
using ConnectedDevelopment.InformSystem.WebApi.Client.Assemblies;
using ConnectedDevelopment.InformSystem.WebApi.Client.BearerTokenProviders;
using ConnectedDevelopment.InformSystem.WebApi.Client.BearerTokenProviders.Decorators;
using System;
using System.Linq;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register bearer token provider in Autofac
    /// </summary>
    public class BearerTokenProviderRegistration : IAutofacRegistration
    {
        private readonly IAssemblyProvider _assemblyProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="BearerTokenProviderRegistration"/> class.
        /// </summary>
        public BearerTokenProviderRegistration(
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

            var serviceType = typeof(IBearerTokenProvider<>);

            var decoratorTypes = new Type[]
            {
                typeof(ExpiresBearerTokenProviderDecorator<>),
                typeof(CacheBearerTokenProviderDecorator<>),
                typeof(EnsureSuccessBearerTokenProviderDecorator<>),
            };

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

            foreach (var decoratorType in decoratorTypes)
            {
                builder.RegisterGenericDecorator(decoratorType, serviceType);
            }
        }
    }
}
