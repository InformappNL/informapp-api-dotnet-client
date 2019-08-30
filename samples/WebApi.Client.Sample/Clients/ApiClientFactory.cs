using Informapp.InformSystem.WebApi.Client.BearerTokenProviders;
using Informapp.InformSystem.WebApi.Client.BearerTokenProviders.Decorators;
using Informapp.InformSystem.WebApi.Client.Caches;
using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Clients.Decorators;
using Informapp.InformSystem.WebApi.Client.Converters;
using Informapp.InformSystem.WebApi.Client.CredentialsProviders;
using Informapp.InformSystem.WebApi.Client.DateTimeProviders;
using Informapp.InformSystem.WebApi.Client.DictionaryBuilders;
using Informapp.InformSystem.WebApi.Client.EndPointProviders;
using Informapp.InformSystem.WebApi.Client.Files;
using Informapp.InformSystem.WebApi.Client.MethodProviders;
using Informapp.InformSystem.WebApi.Client.PathProviders;
using Informapp.InformSystem.WebApi.Client.QueryStringProviders;
using Informapp.InformSystem.WebApi.Client.QueryStrings;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.RestSharp.ClientFactories;
using Informapp.InformSystem.WebApi.Client.RestSharp.ClientFactories.Decorators;
using Informapp.InformSystem.WebApi.Client.RestSharp.Clients;
using Informapp.InformSystem.WebApi.Client.RestSharp.Converters;
using Informapp.InformSystem.WebApi.Client.RestSharp.RequestFactories;
using Informapp.InformSystem.WebApi.Client.RestSharp.RequestFactories.Decorators;
using Informapp.InformSystem.WebApi.Client.RestSharp.Serializers;
using Informapp.InformSystem.WebApi.Client.Sample.BearerTokenProviders;
using Informapp.InformSystem.WebApi.Client.Validators;
using Informapp.InformSystem.WebApi.Models.Http;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.OAuth2.OAuth2Token;
using RestSharp;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Informapp.InformSystem.WebApi.Client.Sample.Clients
{
    /// <summary>
    /// Factory class to create instances of <see cref="IApiClient{TRequest, TResponse}"/>
    /// </summary>
    internal class ApiClientFactory : IApiClientFactory
    {
        /// <summary>
        /// Create instace of <see cref="IApiClient{TRequest, TResponse}"/>
        /// </summary>
        /// <typeparam name="TRequest">The request type</typeparam>
        /// <typeparam name="TResponse">The response type</typeparam>
        /// <returns>An instance of <see cref="IApiClient{TRequest, TResponse}"/></returns>
        public IApiClient<TRequest, TResponse> Create<TRequest, TResponse>()
            where TRequest : class, IRequest<TResponse>
            where TResponse : class, new()
        {
            var apiClient = GetApiClient<TRequest, TResponse>();

            return apiClient;
        }

        private static IApiClient<TRequest, TResponse> GetApiClient<TRequest, TResponse>()
            where TRequest : class, IRequest<TResponse>
            where TResponse : class, new()
        {
            IApiClient<TRequest, TResponse> apiClient = new RestSharpApiClient<TRequest, TResponse>(
                GetClientFactory(), 
                GetRequestFactory(), 
                GetQueryStringBuilderFactory(), 
                GetResponseStatusConverter());

            apiClient = new DownloadFileApiClientDecorator<TRequest, TResponse>(apiClient, GetDownloadFileMappers<TRequest, TResponse>());

            apiClient = new UploadFileApiClientDecorator<TRequest, TResponse>(apiClient, GetUploadFileMappers<TRequest, TResponse>());

            apiClient = new ContentModelApiClientDecorator<TRequest, TResponse>(apiClient);

            apiClient = new LogToConsoleApiClientDecorator<TRequest, TResponse>(apiClient);

            apiClient = new ResultNullApiClientDecorator<TRequest, TResponse>(apiClient);

            apiClient = new ElapsedApiClientDecorator<TRequest, TResponse>(apiClient);

            apiClient = new RequestIdApiClientDecorator<TRequest, TResponse>(apiClient, GetStringToGuidConverter());

            apiClient = new TotalCountApiClientDecorator<TRequest, TResponse>(apiClient);

            apiClient = new ValidateResponseModelApiClientDecorator<TRequest, TResponse>(apiClient, GetValidator<TResponse>());

            apiClient = new ValidateBearerTokenApiClientDecorator<TRequest, TResponse>(apiClient, GetValidator<ApiBearerToken>());

            apiClient = new BearerTokenApiClientDecorator<TRequest, TResponse>(apiClient, GetBearerTokenProvider());

            apiClient = new ValidateCredentialsApiClientDecorator<TRequest, TResponse>(apiClient, GetValidator<ApiCredentials>());

            apiClient = new CredentialsApiClientDecorator<TRequest, TResponse>(apiClient, GetCredentialsProvider());

            apiClient = new ValidateRequestContextApiClientDecorator<TRequest, TResponse>(apiClient, GetValidator<RequestContext>());

            //apiClient = new MethodeOverrideApiClientDecorator<TRequest, TResponse>(apiClient);

            apiClient = new AcceptContentTypeApiClientDecorator<TRequest, TResponse>(apiClient);

            apiClient = new ContentTypeApiClientDecorator<TRequest, TResponse>(apiClient);

            apiClient = new AnonymousApiClientDecorator<TRequest, TResponse>(apiClient);

            apiClient = new MethodApiClientDecorator<TRequest, TResponse>(apiClient, GetMethodProvider<TRequest>());

            apiClient = new QueryApiClientDecorator<TRequest, TResponse>(apiClient, GetQueryProvider<TRequest>());

            apiClient = new PathApiClientDecorator<TRequest, TResponse>(apiClient, GetPathProvider<TRequest>());

            apiClient = new RequireHttpsApiClientDecorator<TRequest, TResponse>(apiClient);

            apiClient = new EndPointApiClientDecorator<TRequest, TResponse>(apiClient, GetEndPointProvider());

            //apiClient = new EnsureSuccessApiClientDecorator<TRequest, TResponse>(apiClient);

            apiClient = new ValidateRequestModelApiClientDecorator<TRequest, TResponse>(apiClient, GetValidator<TRequest>());

            //apiClient = new ArgumentNullApiClientDecorator<TRequest, TResponse>(apiClient);

            return apiClient;
        }

        private static Lazy<IApiClient<TRequest, TResponse>> GetLazyApiClient<TRequest, TResponse>()
            where TRequest : class, IRequest<TResponse>
            where TResponse : class, new()
        {
            return new Lazy<IApiClient<TRequest, TResponse>>(() => GetApiClient<TRequest, TResponse>());
        }

        private static readonly IBearerTokenCache _bearerTokenCache = GetBearerTokenCache();

        private static IBearerTokenCache GetBearerTokenCache()
        {
            int concurrencyLevel = 4;

            int capacity = 10;

            var comparer = new BearerTokenKeyEqualityComparer();

            var dictionary = new ConcurrentDictionary<BearerTokenKey, BearerTokenResponse>(concurrencyLevel, capacity, comparer);

            ICache<BearerTokenKey, BearerTokenResponse> cache = new DictionaryCache<BearerTokenKey, BearerTokenResponse>(dictionary);

            return new BearerTokenCache(cache);
        }

        private static IBearerTokenProvider<OAuth2TokenV1Request> GetBearerTokenProvider()
        {
            IBearerTokenProvider<OAuth2TokenV1Request> tokenProvider = new BearerTokenV1Provider(
                GetLazyApiClient<OAuth2TokenV1Request, OAuth2TokenV1Response>());

            tokenProvider = new ExpiresBearerTokenProviderDecorator<OAuth2TokenV1Request>(tokenProvider, GetDateTimeProvider());

            tokenProvider = new LogToConsoleBearerTokenProviderDecorator<OAuth2TokenV1Request>(tokenProvider);

            tokenProvider = new CacheBearerTokenProviderDecorator<OAuth2TokenV1Request>(tokenProvider, _bearerTokenCache, GetDateTimeProvider(), new ApiRequestToBearerTokenKeyConverter());

            tokenProvider = new EnsureSuccessBearerTokenProviderDecorator<OAuth2TokenV1Request>(tokenProvider);

            return tokenProvider;
        }

        private static readonly IClientCache _clientCache = GetClientCache();

        private static IClientCache GetClientCache()
        {
            int concurrencyLevel = 4;

            int capacity = 10;

            var dictionary = new ConcurrentDictionary<Uri, IRestClient>(concurrencyLevel, capacity);

            ICache<Uri, IRestClient> cache = new DictionaryCache<Uri, IRestClient>(dictionary);

            return new ClientCache(cache);
        }

        private static IClientFactory GetClientFactory()
        {
            IClientFactory clientFactory = new ClientFactory();

            clientFactory = new SerializerClientFactoryDecorator(clientFactory, new JsonNetSerializer());

            clientFactory = new RequireHttpsClientFactoryDecorator(clientFactory);

            clientFactory = new CacheClientFactoryDecorator(clientFactory, _clientCache);

            return clientFactory;
        }

        private static ICredentialsProvider GetCredentialsProvider()
        {
            return new ConfigurationCredentialsProvider();
        }

        private static IDateTimeProvider GetDateTimeProvider()
        {
            return new DateTimeProvider();
        }

        private static IEnumerable<IDownloadFileMapper<TRequest, TResponse>> GetDownloadFileMappers<TRequest, TResponse>()
            where TRequest : class, IRequest<TResponse>
            where TResponse : class, new()
        {
            var mappers = new IDownloadFileMapper<TRequest, TResponse>[]
            {
                new DownloadFileV1Mapper<TRequest, TResponse>(),
                new DownloadFileV2Mapper<TRequest, TResponse>(),
            };

            return mappers;
        }

        private static IEndPointProvider GetEndPointProvider()
        {
            return new ConfigurationEndPointProvider();
        }

        private static IConverter<HttpMethod?, Method?> GetHttpVerbConverter()
        {
            return new HttpMethodConverter();
        }

        private static IMethodProvider<T> GetMethodProvider<T>()
            where T : class
        {
            return new MethodProvider<T>();
        }

        private static IPathProvider<T> GetPathProvider<T>()
            where T : class
        {
            return new PathProvider<T>();
        }

        private static IQueryDictionaryBuilder<T> GetQueryDictionaryBuilder<T>()
            where T : class
        {
            return new QueryDictionaryBuilder<T>();
        }

        private static IQueryProvider<T> GetQueryProvider<T>()
            where T : class
        {
            return new QueryProvider<T>(
                GetQueryDictionaryBuilder<T>(), 
                GetQueryStringBuilderFactory());
        }

        private static IQueryStringBuilderFactory GetQueryStringBuilderFactory()
        {
            return new QueryStringBuilderFactory();
        }

        private static IRequestFactory GetRequestFactory()
        {
            IRequestFactory requestFactory = new RequestFactory(GetHttpVerbConverter());

            requestFactory = new AcceptContentTypeRequestFactoryDecorator(requestFactory);

            requestFactory = new BearerTokenRequestFactoryDecorator(requestFactory);

            requestFactory = new MethodOverrideRequestFactoryDecorator(requestFactory);

            return requestFactory;
        }

        private static IConverter<ResponseStatus?, ResponseStatusCode?> GetResponseStatusConverter()
        {
            return new ResponseStatusConverter();
        }

        private static IConverter<string, Guid?> GetStringToGuidConverter()
        {
            return new StringToGuidConverter();
        }

        private static IEnumerable<IUploadFileMapper<TRequest, TResponse>> GetUploadFileMappers<TRequest, TResponse>()
            where TRequest : class, IRequest<TResponse>
            where TResponse : class, new()
        {
            var mappers = new IUploadFileMapper<TRequest, TResponse>[]
            {
                new UploadFileV1Mapper<TRequest, TResponse>(),
                new UploadFileV2Mapper<TRequest, TResponse>(),
            };

            return mappers;
        }

        private static IValidator<T> GetValidator<T>()
            where T : class
        {
            return new Validator<T>();
        }
    }
}
