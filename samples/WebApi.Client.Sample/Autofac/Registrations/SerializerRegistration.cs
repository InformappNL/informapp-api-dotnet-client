using Autofac;
using ConnectedDevelopment.InformSystem.WebApi.Client.RestSharp.Serializers;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using RestSharp.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Autofac.Registrations
{
    /// <summary>
    /// Register dependencies in Autofac
    /// </summary>
    public class SerializerRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register dependencies in Autofac
        /// </summary>
        /// <param name="builder">The builder</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterType<JsonNetSerializer>()
                .As<IRestSerializer>()
                .InstancePerLifetimeScope();
        }
    }
}
