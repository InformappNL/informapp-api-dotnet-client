using Autofac;
using Informapp.InformSystem.WebApi.Client.RestSharp.Deserializers;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;

namespace Informapp.InformSystem.WebApi.Client.Sample.Autofac.Registrations
{
    /// <summary>
    /// Register dependencies in Autofac
    /// </summary>
    internal class JsonDeserializerRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register dependencies in Autofac
        /// </summary>
        /// <param name="builder">The builder</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            builder.RegisterType<NewtonSoftJsonDeserializer>()
                .As<IJsonDeserializer>()
                .InstancePerLifetimeScope();
        }
    }
}
