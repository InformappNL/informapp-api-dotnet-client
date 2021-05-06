using Autofac;
using Informapp.InformSystem.IntegrationTool.Core.IO;
using System.IO.Abstractions;

namespace Informapp.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register directory info factory in Autofac
    /// </summary>
    public class DirectoryInfoFactoryRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterType<DirectoryInfoFactory>()
                .As<IDirectoryInfoFactory>()
                .InstancePerLifetimeScope();
        }
    }
}
