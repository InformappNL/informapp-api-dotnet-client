using Autofac;
using Informapp.InformSystem.WebApi.Client.RestSharp.Serializers;

using RestSharp.Serialization;

namespace Informapp.InformSystem.IntegrationTool.App.Autofac.Registrations
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
