﻿using Autofac;
using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Clients.Decorators;
using Informapp.InformSystem.WebApi.Client.RestSharp.Clients;
using Informapp.InformSystem.IntegrationTool.Core.Clients;
using System;

namespace Informapp.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register api client in Autofac
    /// </summary>
    public class ApiClientRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            var serviceType = typeof(IApiClient<,>);

            var decoratorTypes = new Type[]
            {
                typeof(DownloadFileApiClientDecorator<,>),
                typeof(DisposableResponseApiClientDecorator<,>),
                typeof(DisposableRequestApiClientDecorator<,>),
                typeof(UploadFileResponseApiClientDecorator<,>),
                typeof(ValidateUploadFileResponseApiClientDecorator<,>),
                typeof(UploadFileRequestApiClientDecorator<,>),
                typeof(ContentModelApiClientDecorator<,>),
                typeof(ResultNullApiClientDecorator<,>),
                typeof(ElapsedApiClientDecorator<,>),
                typeof(RequestIdApiClientDecorator<,>),
                typeof(TotalCountApiClientDecorator<,>),
                typeof(LogApiClientDecorator<,>),
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
                .As(serviceType)
                .InstancePerLifetimeScope();

            foreach (var decoratorType in decoratorTypes)
            {
                builder.RegisterGenericDecorator(decoratorType, serviceType);
            }
        }
    }
}
