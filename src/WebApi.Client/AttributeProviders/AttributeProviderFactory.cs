using System;

namespace Informapp.InformSystem.WebApi.Client.AttributeProviders
{
    /// <summary>
    /// Factory class to create instances of <see cref="IAttributeProvider{TType, TAttribute}"/>
    /// </summary>
    internal class AttributeProviderFactory : IAttributeProviderFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeProviderFactory"/> class.
        /// </summary>
        public AttributeProviderFactory()
        {

        }

        /// <summary>
        /// Create instance of <see cref="IAttributeProvider{TType, TAttribute}"/>
        /// </summary>
        /// <typeparam name="TType">The type</typeparam>
        /// <typeparam name="TAttribute">The attribute type</typeparam>
        /// <param name="inherit">true to search the inheritance chain to find the attributes; otherwise, false</param>
        /// <returns>The attribute provider</returns>
        public IAttributeProvider<TType, TAttribute> Create<TType, TAttribute>(bool inherit)
            where TAttribute : Attribute
        {
            var provider = new AttributeProvider<TType, TAttribute>(inherit);

            return provider;
        }
    }
}
