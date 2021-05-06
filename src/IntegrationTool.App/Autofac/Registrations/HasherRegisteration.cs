using Autofac;
using Informapp.InformSystem.WebApi.Client.Cryptography;

namespace Informapp.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register hasher in Autofac
    /// </summary>
    public class HasherRegisteration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterType<Hasher>()
                .As<IHasher>()
                .InstancePerLifetimeScope();
        }
    }
}
