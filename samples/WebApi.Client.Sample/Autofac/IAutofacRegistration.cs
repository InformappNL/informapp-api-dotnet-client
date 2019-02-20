using Autofac;

namespace Informapp.InformSystem.WebApi.Client.Sample.Autofac
{
    /// <summary>
    /// Interface to register dependencies with Autofac
    /// </summary>
    internal interface IAutofacRegistration
    {
        /// <summary>
        /// Register dependencies
        /// </summary>
        /// <param name="builder">The builder instance to add registrations to</param>
        void Register(ContainerBuilder builder);
    }
}
