﻿using Autofac;
using ConnectedDevelopment.InformSystem.WebApi.Client.QueryStringProviders;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Autofac.Registrations
{
    /// <summary>
    /// Register dependencies in Autofac
    /// </summary>
    public class QueryProviderRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register dependencies in Autofac
        /// </summary>
        /// <param name="builder">The builder</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterGeneric(typeof(QueryProvider<>))
                .As(typeof(IQueryProvider<>))
                .InstancePerLifetimeScope();
        }
    }
}
