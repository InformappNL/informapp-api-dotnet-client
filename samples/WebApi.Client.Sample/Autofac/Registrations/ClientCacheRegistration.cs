using Autofac;
using Informapp.InformSystem.WebApi.Client.Caches;
using Informapp.InformSystem.WebApi.Client.Caches.Decorators;
using Informapp.InformSystem.WebApi.Client.RestSharp.ClientFactories;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using RestSharp;
using System;
using System.Collections.Concurrent;

namespace Informapp.InformSystem.WebApi.Client.Sample.Autofac.Registrations
{
    /// <summary>
    /// Register dependencies in Autofac
    /// </summary>
    internal class ClientCacheRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register dependencies in Autofac
        /// </summary>
        /// <param name="builder">The builder</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            builder.Register(x => new ClientCache(GetCache()))
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
