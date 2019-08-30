using Informapp.InformSystem.WebApi.Client.Arguments;
using System;
using System.Globalization;

namespace Informapp.InformSystem.WebApi.Client.AttributeProviders
{
    /// <summary>
    /// Static class with extension methods for <see cref="IAttributeProvider{TType, TAttribute}"/>
    /// </summary>
    internal static class AttributeProviderExtensions
    {
        /// <summary>
        /// Determines whether <paramref name="provider"/> contains any attributes
        /// </summary>
        /// <typeparam name="TType">The type</typeparam>
        /// <typeparam name="TAttribute">The attribute type</typeparam>
        /// <param name="provider">The provider</param>
        /// <returns>true if the <paramref name="provider"/> contains any attributes; otherwise, false</returns>
        public static bool Any<TType, TAttribute>(this IAttributeProvider<TType, TAttribute> provider)
            where TAttribute : Attribute
        {
            Argument.NotNull(provider, nameof(provider));

            bool any = provider.Count > 0;

            return any;
        }

        /// <summary>
        /// Throws <see cref="InvalidOperationException"/> when <paramref name="provider"/> contains multiple attributes
        /// </summary>
        /// <typeparam name="TType">The type</typeparam>
        /// <typeparam name="TAttribute">The attribute type</typeparam>
        /// <param name="provider">The provider</param>
        /// <returns>The provider</returns>
        /// <exception cref="InvalidOperationException"><paramref name="provider"/> contains multiple attributes</exception>
        public static IAttributeProvider<TType, TAttribute> ThrowIfMultiple<TType, TAttribute>(
            this IAttributeProvider<TType, TAttribute> provider)

            where TAttribute : Attribute
        {
            Argument.NotNull(provider, nameof(provider));

            if (provider.Count > 1)
            {
                Throw(provider, "Number of {0} attributes on type {1} is greater than one");
            }

            return provider;
        }

        /// <summary>
        /// Throws <see cref="InvalidOperationException"/> when <paramref name="provider"/> contains no attributes
        /// </summary>
        /// <typeparam name="TType">The type</typeparam>
        /// <typeparam name="TAttribute">The attribute type</typeparam>
        /// <param name="provider">The provider</param>
        /// <returns>The provider</returns>
        /// <exception cref="InvalidOperationException"><paramref name="provider"/> contains no attributes</exception>
        public static IAttributeProvider<TType, TAttribute> ThrowIfNone<TType, TAttribute>(
            this IAttributeProvider<TType, TAttribute> provider)

            where TAttribute : Attribute
        {
            Argument.NotNull(provider, nameof(provider));

            if (provider.Count == 0)
            {
                Throw(provider, "Number of {0} attributes on type {1} is zero");
            }

            return provider;
        }

        /// <summary>
        /// Throws <see cref="InvalidOperationException"/> when <paramref name="provider"/> contains any attributes
        /// </summary>
        /// <typeparam name="TType">The type</typeparam>
        /// <typeparam name="TAttribute">The attribute type</typeparam>
        /// <param name="provider">The provider</param>
        /// <returns>The provider</returns>
        /// <exception cref="InvalidOperationException"><paramref name="provider"/> contains any attributes</exception>
        public static IAttributeProvider<TType, TAttribute> ThrowIfAny<TType, TAttribute>(
            this IAttributeProvider<TType, TAttribute> provider)

            where TAttribute : Attribute
        {
            Argument.NotNull(provider, nameof(provider));

            if (provider.Count > 0)
            {
                Throw(provider, "Number of {0} attributes on type {1} is greater than zero");
            }

            return provider;
        }

        /// <summary>
        /// Throws <see cref="InvalidOperationException"/> when <paramref name="provider"/> contains one attributes
        /// </summary>
        /// <typeparam name="TType">The type</typeparam>
        /// <typeparam name="TAttribute">The attribute type</typeparam>
        /// <param name="provider">The provider</param>
        /// <returns>The provider</returns>
        /// <exception cref="InvalidOperationException"><paramref name="provider"/> contains one attributes</exception>
        public static IAttributeProvider<TType, TAttribute> ThrowIfOne<TType, TAttribute>(
            this IAttributeProvider<TType, TAttribute> provider)

            where TAttribute : Attribute
        {
            Argument.NotNull(provider, nameof(provider));

            if (provider.Count == 1)
            {
                Throw(provider, "Number of {0} attributes on type {1} is equal to one");
            }

            return provider;
        }

        /// <summary>
        /// Throws <see cref="InvalidOperationException"/> when <paramref name="provider"/> contains not one attributes
        /// </summary>
        /// <typeparam name="TType">The type</typeparam>
        /// <typeparam name="TAttribute">The attribute type</typeparam>
        /// <param name="provider">The provider</param>
        /// <returns>The provider</returns>
        /// <exception cref="InvalidOperationException"><paramref name="provider"/> contains not one attributes</exception>
        public static IAttributeProvider<TType, TAttribute> ThrowIfNotOne<TType, TAttribute>(
            this IAttributeProvider<TType, TAttribute> provider)

            where TAttribute : Attribute
        {
            Argument.NotNull(provider, nameof(provider));

            if (provider.Count != 1)
            {
                Throw(provider, "Number of {0} attributes on type {1} is not equal to one");
            }

            return provider;
        }

        private static void Throw<TType, TAttribute>(
            IAttributeProvider<TType, TAttribute> provider,
            string format)

            where TAttribute : Attribute
        {
            _ = provider;

            string message = string.Format(
                CultureInfo.InvariantCulture,
                format,
                typeof(TAttribute).Name,
                typeof(TType).Name);

            throw new InvalidOperationException(message);
        }
    }
}
