using Autofac;
using Informapp.InformSystem.WebApi.Client.RestSharp.ClientFactories;
using Informapp.InformSystem.WebApi.Client.RestSharp.ClientFactories.Decorators;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using System;

namespace Informapp.InformSystem.WebApi.Client.Sample.Autofac.Registrations
{
    /// <summary>
    /// Register dependencies in Autofac
    /// </summary>
    internal class ClientFactoryRegistration : IAutofacRegistration
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
             * the first decorator acts directly on ClientFactory
             * the last decorator is the one you get when resolving an instance of IClientFactory
             * 
             */
            var decorators = new Type[]
            {
                typeof(JsonDeserializerClientFactoryDecorator),
                typeof(RequireHttpsClientFactoryDecorator),
                typeof(CacheClientFactoryDecorator)
            };

            builder.RegisterType<ClientFactory>()
                .As<IClientFactory>()
                .InstancePerLifetimeScope();

            foreach (var decorator in decorators)
            {
                builder.RegisterDecorator(decorator, typeof(IClientFactory));
            }
        }
    }
}
