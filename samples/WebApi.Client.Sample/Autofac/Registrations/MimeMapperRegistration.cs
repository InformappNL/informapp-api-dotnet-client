﻿using Autofac;
using ConnectedDevelopment.InformSystem.WebApi.Client.MimeMappers;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Autofac.Registrations
{
    /// <summary>
    /// Register dependencies in Autofac
    /// </summary>
    public class MimeMapperRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register dependencies in Autofac
        /// </summary>
        /// <param name="builder">The builder</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterType<MimeMapper>()
                .As<IMimeMapper>()
                .InstancePerLifetimeScope();
        }
    }
}
