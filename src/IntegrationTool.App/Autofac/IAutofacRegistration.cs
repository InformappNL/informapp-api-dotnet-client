using Autofac;

namespace Informapp.InformSystem.IntegrationTool.App.Autofac
{
    /// <summary>
    /// Abstraction to register services with Autofac
    /// </summary>
    public interface IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        void Register(ContainerBuilder builder);
    }
}
