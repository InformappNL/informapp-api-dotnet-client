using Autofac;
using Informapp.InformSystem.WebApi.Client.Validators;

namespace Informapp.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register dependencies in Autofac
    /// </summary>
    public class ValidatorRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register dependencies in Autofac
        /// </summary>
        /// <param name="builder">The builder</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterType<ValidatorWrapper>()
                .As<IValidator>()
                .InstancePerLifetimeScope();
        }
    }
}
