using Autofac;
using ConnectedDevelopment.InformSystem.WebApi.Client.BearerTokenProviders;
using ConnectedDevelopment.InformSystem.WebApi.Client.Caches;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using System.Collections.Concurrent;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Autofac.Registrations
{
    /// <summary>
    /// Register dependencies in Autofac
    /// </summary>
    public class BearerTokenCacheRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register dependencies in Autofac
        /// </summary>
        /// <param name="builder">The builder</param>
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
