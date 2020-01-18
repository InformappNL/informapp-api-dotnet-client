﻿using Autofac;
using Informapp.InformSystem.WebApi.Client.BearerTokenProviders;
using Informapp.InformSystem.WebApi.Client.BearerTokenProviders.Decorators;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.BearerTokenProviders;
using System;
using System.Linq;

namespace Informapp.InformSystem.WebApi.Client.Sample.Autofac.Registrations
{
    /// <summary>
    /// Register dependencies in Autofac
    /// </summary>
    internal class BearerTokenProviderRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register dependencies in Autofac
        /// </summary>
        /// <param name="builder">The builder</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            var serviceType = typeof(IBearerTokenProvider<>);

            /* 
             * The decorators to apply, from inner to outer
             * the first decorator acts directly on BearerTokenProvider
             * the last decorator is the one you get when resolving an instance of IBearerTokenProvider
             * 
             */
            var decoratorTypes = new Type[]
            {
                typeof(ExpiresBearerTokenProviderDecorator<>),
                typeof(LogToConsoleBearerTokenProviderDecorator<>),
                typeof(CacheBearerTokenProviderDecorator<>),
                typeof(EnsureSuccessBearerTokenProviderDecorator<>),
            };

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => x.IsGenericType == false)
                .SelectMany(x => x.GetInterfaces(), (i, s) => (Implementor: i, Service: s))
                .Where(x => x.Service.IsGenericType == true)
                .Where(x => x.Service.ContainsGenericParameters == false)
                .Where(x => x.Service.GetGenericTypeDefinition() == typeof(IBearerTokenProvider<>))
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
