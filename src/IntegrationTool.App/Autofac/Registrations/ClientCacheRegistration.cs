using Autofac;
using ConnectedDevelopment.InformSystem.WebApi.Client.Caches;
using ConnectedDevelopment.InformSystem.WebApi.Client.Caches.Decorators;
using ConnectedDevelopment.InformSystem.WebApi.Client.RestSharp.ClientFactories;
using RestSharp;
using System;
using System.Collections.Concurrent;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register client cache in Autofac
    /// </summary>
    public class ClientCacheRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.Register(x => new ClientCache(GetCache()))
                .As<IClientCache>()
                .SingleInstance();
        }

        private static ICache<Uri, IRestClient> GetCache()
        {
            int concurrencyLevel = 4;

            int capacity = 10;

            var dictionary = new ConcurrentDictionary<Uri, IRestClient>(concurrencyLevel, capacity);

            ICache<Uri, IRestClient> cache = new DictionaryCache<Uri, IRestClient>(dictionary);

            cache = new DisposableCacheDecorator<Uri, IRestClient>(cache);

            return cache;
        }
    }
}
