using Autofac;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Validators;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Autofac.Registrations
{
    /// <summary>
    /// Register dependencies in Autofac
    /// </summary>
    public class ValidatorT1Registration : IAutofacRegistration
    {
        /// <summary>
        /// Register dependencies in Autofac
        /// </summary>
        /// <param name="builder">The builder</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterGeneric(typeof(Validator<>))
                .As(typeof(IValidator<>))
                .InstancePerLifetimeScope();
        }
    }
}
