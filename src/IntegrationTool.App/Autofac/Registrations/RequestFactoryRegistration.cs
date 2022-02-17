using Autofac;
using ConnectedDevelopment.InformSystem.WebApi.Client.RestSharp.RequestFactories;
using ConnectedDevelopment.InformSystem.WebApi.Client.RestSharp.RequestFactories.Decorators;
using System;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register request factory in Autofac
    /// </summary>
    public class RequestFactoryRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            var serviceType = typeof(IRequestFactory);

            var decoratorTypes = new Type[]
            {
                typeof(AcceptContentTypeRequestFactoryDecorator),
                typeof(BearerTokenRequestFactoryDecorator),
                typeof(MethodOverrideRequestFactoryDecorator),
            };

            _ = builder.RegisterType<RequestFactory>()
                .As<IRequestFactory>()
                .InstancePerLifetimeScope();

            foreach (var decoratorType in decoratorTypes)
            {
                builder.RegisterDecorator(decoratorType, serviceType);
            }
        }
    }
}
