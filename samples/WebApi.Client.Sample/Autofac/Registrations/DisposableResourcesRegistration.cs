using Autofac;
using Informapp.InformSystem.WebApi.Client.Disposables;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Autofac.Registrations
{
    /// <summary>
    /// Register dependencies in Autofac
    /// </summary>
    internal class DisposableResourcesRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register dependencies in Autofac
        /// </summary>
        /// <param name="builder">The builder</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            builder.RegisterType<DisposableResources>()
                .As<IDisposableResources>()
                .InstancePerDependency();
        }
    }
}
