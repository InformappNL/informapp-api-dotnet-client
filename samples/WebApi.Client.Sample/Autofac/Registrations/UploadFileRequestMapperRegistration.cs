using Autofac;
using Informapp.InformSystem.WebApi.Client.Files;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;

namespace Informapp.InformSystem.WebApi.Client.Sample.Autofac.Registrations
{
    /// <summary>
    /// Register dependencies in Autofac
    /// </summary>
    internal class UploadFileRequestMapperRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register dependencies in Autofac
        /// </summary>
        /// <param name="builder">The builder</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterGeneric(typeof(UploadFileV1RequestMapper<,>))
                .As(typeof(IUploadFileRequestMapper<,>))
                .InstancePerLifetimeScope();

            _ = builder.RegisterGeneric(typeof(UploadFileV2RequestMapper<,>))
                .As(typeof(IUploadFileRequestMapper<,>))
                .InstancePerLifetimeScope();
        }
    }
}
