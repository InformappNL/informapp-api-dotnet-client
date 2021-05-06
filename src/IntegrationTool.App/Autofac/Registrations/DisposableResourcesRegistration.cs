using Autofac;
using Informapp.InformSystem.WebApi.Client.Disposables;

namespace Informapp.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register disposable resources in Autofac
    /// </summary>
    public class DisposableResourcesRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterType<DisposableResources>()
                .As<IDisposableResources>()
                .InstancePerDependency();
        }
    }
}
