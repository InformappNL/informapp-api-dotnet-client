using Autofac;
using Informapp.InformSystem.WebApi.Client.RestSharp.ClientFactories;
using Informapp.InformSystem.WebApi.Client.RestSharp.ClientFactories.Decorators;
using Informapp.InformSystem.IntegrationTool.App.ClientFactories;
using System;

namespace Informapp.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register client cache factory in Autofac
    /// </summary>
    public class ClientFactoryRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            var serviceType = typeof(IClientFactory);

            var decoratorTypes = new Type[]
            {
                typeof(SerializerClientFactoryDecorator),
                typeof(RequireHttpsClientFactoryDecorator),
                typeof(UserAgentClientFactoryDecorator),
                typeof(CacheClientFactoryDecorator),
            };

            _ = builder.RegisterType<ClientFactory>()
                .As<IClientFactory>()
                .InstancePerLifetimeScope();

            foreach (var decoratorType in decoratorTypes)
            {
                builder.RegisterDecorator(decoratorType, serviceType);
            }
        }
    }
}
