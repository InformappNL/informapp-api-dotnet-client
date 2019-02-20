using Informapp.InformSystem.WebApi.Client.Arguments;
using Informapp.InformSystem.WebApi.Client.Requires;
using System;

namespace Informapp.InformSystem.WebApi.Client.AttributeProviders
{
    /// <summary>
    /// Static factory class for creating instances of <see cref="IAttributeProvider{TType, TAttribute}"/>
    /// </summary>
    internal static class AttributeProvider
    {
        private static IAttributeProviderFactory _factory = new AttributeProviderFactory();

        /// <summary>
        /// Set the factory to use to create instances
        /// </summary>
        /// <param name="factory">The factory</param>
        public static void SetFactory(IAttributeProviderFactory factory)
        {
            Argument.NotNull(factory, nameof(factory));

            _factory = factory;
        }

        /// <summary>
        /// Create instance of <see cref="IAttributeProvider{TType, TAttribute}"/>
        /// </summary>
        /// <typeparam name="TType">The type</typeparam>
        /// <typeparam name="TAttribute">The attribute type</typeparam>
        /// <param name="inherit">true to search the inheritance chain to find the attributes; otherwise, false</param>
        /// <returns>A new provider</returns>
        public static IAttributeProvider<TType, TAttribute> Create<TType, TAttribute>(bool inherit)
            where TAttribute : Attribute
        {
            var provider = _factory.Create<TType, TAttribute>(inherit);

            Require.NotNull(provider, nameof(provider));

            return provider;
        }
    }
}
