using Autofac;
using System.IO.Abstractions;

namespace Informapp.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register path in Autofac
    /// </summary>
    public class FilePathProviderRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterType<PathWrapper>()
                .As<IPath>()
                .InstancePerLifetimeScope();
        }
    }
}
