using Autofac;
using Informapp.InformSystem.WebApi.Client.BearerTokenProviders;
using Informapp.InformSystem.WebApi.Client.Caches;
using System.Collections.Concurrent;

namespace Informapp.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register bearer token cache in Autofac
    /// </summary>
    public class BearerTokenCacheRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.Register(x => new BearerTokenCache(GetCache()))
                .As<IBearerTokenCache>()
                .SingleInstance();
        }

        private static ICache<BearerTokenKey, BearerTokenResponse> GetCache()
        {
            int concurrencyLevel = 4;

            int capacity = 10;

            var comparer = new BearerTokenKeyEqualityComparer();

            var dictionary = new ConcurrentDictionary<BearerTokenKey, BearerTokenResponse>(concurrencyLevel, capacity, comparer);

            ICache<BearerTokenKey, BearerTokenResponse> cache = new DictionaryCache<BearerTokenKey, BearerTokenResponse>(dictionary);

            return cache;
        }
    }
}
