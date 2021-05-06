using Autofac;
using Informapp.InformSystem.WebApi.Client.Files;

namespace Informapp.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register upload file request mapper in Autofac
    /// </summary>
    public class UploadFileRequestMapperRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
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
