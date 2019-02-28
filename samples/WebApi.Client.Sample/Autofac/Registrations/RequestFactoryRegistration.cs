using Autofac;
using Informapp.InformSystem.WebApi.Client.RestSharp.RequestFactories;
using Informapp.InformSystem.WebApi.Client.RestSharp.RequestFactories.Decorators;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using System;

namespace Informapp.InformSystem.WebApi.Client.Sample.Autofac.Registrations
{
    /// <summary>
    /// Register dependencies in Autofac
    /// </summary>
    internal class RequestFactoryRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register dependencies in Autofac
        /// </summary>
        /// <param name="builder">The builder</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            var serviceType = typeof(IRequestFactory);

            /* 
             * The decorators to apply, from inner to outer
             * the first decorator acts directly on RequestFactory
             * the last decorator is the one you get when resolving an instance of IRequestFactory
             * 
             */
            var decoratorTypes = new Type[]
            {
                typeof(BearerTokenRequestFactoryDecorator),
                typeof(MethodOverrideRequestFactoryDecorator),
            };

            builder.RegisterType<RequestFactory>()
                .As<IRequestFactory>()
                .InstancePerLifetimeScope();

            foreach (var decoratorType in decoratorTypes)
            {
                builder.RegisterDecorator(decoratorType, serviceType);
            }
        }
    }
}
