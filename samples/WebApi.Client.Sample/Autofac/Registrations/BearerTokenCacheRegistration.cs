using Autofac;
using Informapp.InformSystem.WebApi.Client.BearerTokenProviders;
using Informapp.InformSystem.WebApi.Client.Caches;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using System.Collections.Concurrent;

namespace Informapp.InformSystem.WebApi.Client.Sample.Autofac.Registrations
{
    /// <summary>
    /// Register dependencies in Autofac
    /// </summary>
    internal class BearerTokenCacheRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register dependencies in Autofac
        /// </summary>
        /// <param name="builder">The builder</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            builder.RegisterType<AutofacBearerTokenCache>()
                .As<IBearerTokenCache>()
                .SingleInstance();
        }

        private class AutofacBearerTokenCache : BearerTokenCache
        {
            private static ICache<BearerTokenKey, BearerTokenResponse> GetCache()
            {
                int concurrencyLevel = 4;

                int capacity = 10;

                var comparer = new BearerTokenKeyEqualityComparer();

                var dictionary = new ConcurrentDictionary<BearerTokenKey, BearerTokenResponse>(concurrencyLevel, capacity, comparer);

                ICache<BearerTokenKey, BearerTokenResponse> cache = new DictionaryCache<BearerTokenKey, BearerTokenResponse>(dictionary);

                return cache;
            }

            public AutofacBearerTokenCache() : base(GetCache())
            {

            }
        }
    }
}
