using System;

namespace Informapp.InformSystem.WebApi.Client.AttributeProviders
{
    /// <summary>
    /// Factory interface to create instances of <see cref="IAttributeProvider{TType, TAttribute}"/>
    /// </summary>
    internal interface IAttributeProviderFactory
    {
        /// <summary>
        /// Create instance of <see cref="IAttributeProvider{TType, TAttribute}"/>
        /// </summary>
        /// <typeparam name="TType">The type</typeparam>
        /// <typeparam name="TAttribute">The attribute type</typeparam>
        /// <param name="inherit">true to search the inheritance chain to find the attributes; otherwise, false</param>
        /// <returns>The attribute provider</returns>
        IAttributeProvider<TType, TAttribute> Create<TType, TAttribute>(bool inherit)
            where TAttribute : Attribute;
    }
}
