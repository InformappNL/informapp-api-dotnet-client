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

            /* 
             * The decorators to apply, from inner to outer
             * the first decorator acts directly on RequestFactory
             * the last decorator is the one you get when resolving an instance of IRequestFactory
             * 
             */
            var decorators = new Type[]
            {
                typeof(BearerTokenRequestFactoryDecorator),
                typeof(MethodOverrideRequestFactoryDecorator),
                typeof(JsonSerializerRequestFactoryDecorator),
                //typeof(XmlFormatRequestFactoryDecorator),
            };

            builder.RegisterType<RequestFactory>()
                .As<IRequestFactory>()
                .InstancePerLifetimeScope();

            foreach (var decorator in decorators)
            {
                builder.RegisterDecorator(decorator, typeof(IRequestFactory));
            }
        }
    }
}
