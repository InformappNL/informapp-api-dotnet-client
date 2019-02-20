using Autofac;
using Informapp.InformSystem.WebApi.Client.BearerTokenProviders;
using Informapp.InformSystem.WebApi.Client.BearerTokenProviders.Decorators;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.BearerTokenProviders;
using System;

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

            /* 
             * The decorators to apply, from inner to outer
             * the first decorator acts directly on BearerTokenProvider
             * the last decorator is the one you get when resolving an instance of IBearerTokenProvider
             * 
             */
            var decorators = new Type[]
            {
                typeof(ExpiresBearerTokenProviderDecorator<>),
                typeof(LogToConsoleBearerTokenProviderDecorator<>),
                typeof(CacheBearerTokenProviderDecorator<>),
                typeof(EnsureSuccessBearerTokenProviderDecorator<>),
            };

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .AsClosedTypesOf(typeof(IBearerTokenProvider<>))
                .InstancePerLifetimeScope();

            foreach (var decorator in decorators)
            {
                builder.RegisterGenericDecorator(decorator, typeof(IBearerTokenProvider<>));
            }
        }
    }
}
