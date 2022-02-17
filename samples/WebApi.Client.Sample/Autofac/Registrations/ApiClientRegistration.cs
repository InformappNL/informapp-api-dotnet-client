using Autofac;
using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Clients.Decorators;
using ConnectedDevelopment.InformSystem.WebApi.Client.RestSharp.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Clients;
using System;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Autofac.Registrations
{
    /// <summary>
    /// Register dependencies in Autofac
    /// </summary>
    public class ApiClientRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register dependencies in Autofac
        /// </summary>
        /// <param name="builder">The builder</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            var serviceType = typeof(IApiClient<,>);

            /* 
             * The decorators to apply, from inner to outer
             * the first decorator acts directly on ApiClient<,>
             * the last decorator is the one you get when resolving an instance of IApiClient<,>
             * 
             */
            var decoratorTypes = new Type[]
            {
                typeof(DownloadFileApiClientDecorator<,>),
                typeof(DisposableResponseApiClientDecorator<,>),
                typeof(DisposableRequestApiClientDecorator<,>),
                typeof(UploadFileResponseApiClientDecorator<,>),
                typeof(ValidateUploadFileResponseApiClientDecorator<,>),
                typeof(UploadFileRequestApiClientDecorator<,>),
                typeof(ContentModelApiClientDecorator<,>),
                typeof(LogToConsoleApiClientDecorator<,>),
                typeof(ResultNullApiClientDecorator<,>),
                typeof(ElapsedApiClientDecorator<,>),
                typeof(RequestIdApiClientDecorator<,>),
                typeof(TotalCountApiClientDecorator<,>),
                typeof(ValidateResponseModelApiClientDecorator<,>),
                typeof(ValidateBearerTokenApiClientDecorator<,>),
                //typeof(EnvironmentBearerTokenV1ApiClientDecorator<,>),
                typeof(BearerTokenApiClientDecorator<,>),
                typeof(ValidateCredentialsApiClientDecorator<,>),
                typeof(CredentialsApiClientDecorator<,>),
                typeof(ValidateRequestContextApiClientDecorator<,>),
                //typeof(MethodeOverrideApiClientDecorator<,>),
                typeof(AcceptContentTypeApiClientDecorator<,>),
                typeof(ContentTypeApiClientDecorator<,>),
                typeof(AnonymousApiClientDecorator<,>),
                typeof(MethodApiClientDecorator<,>),
                typeof(QueryApiClientDecorator<,>),
                typeof(PathApiClientDecorator<,>),
                typeof(RequireHttpsApiClientDecorator<,>),
                typeof(EndPointApiClientDecorator<,>),
                //typeof(EnsureSuccessApiClientDecorator<,>),
                typeof(ValidateRequestModelApiClientDecorator<,>),
                //typeof(ArgumentNullApiClientDecorator<,>),
            };

            _ = builder.RegisterGeneric(typeof(RestSharpApiClient<,>))
                .As(typeof(IApiClient<,>))
                .InstancePerLifetimeScope();

            foreach (var decoratorType in decoratorTypes)
            {
                builder.RegisterGenericDecorator(decoratorType, serviceType);
            }
        }
    }
}
