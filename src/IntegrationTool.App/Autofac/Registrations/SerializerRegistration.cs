using Autofac;
using ConnectedDevelopment.InformSystem.WebApi.Client.RestSharp.Serializers;

using RestSharp.Serialization;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register serializer in Autofac
    /// </summary>
    public class SerializerRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterType<JsonNetSerializer>()
                .As<IRestSerializer>()
                .InstancePerLifetimeScope();
        }
    }
}
