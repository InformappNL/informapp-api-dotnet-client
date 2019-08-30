using Autofac;
using Informapp.InformSystem.WebApi.Client.Files;
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
    internal class UploadFileMapperRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register dependencies in Autofac
        /// </summary>
        /// <param name="builder">The builder</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            builder.RegisterGeneric(typeof(UploadFileV1Mapper<,>))
                .As(typeof(IUploadFileMapper<,>))
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(UploadFileV2Mapper<,>))
                .As(typeof(IUploadFileMapper<,>))
                .InstancePerLifetimeScope();
        }
    }
}
