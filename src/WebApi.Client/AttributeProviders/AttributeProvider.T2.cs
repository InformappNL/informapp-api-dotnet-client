using System;
using System.Collections.Generic;
using System.Linq;

namespace Informapp.InformSystem.WebApi.Client.AttributeProviders
{
    /// <summary>
    /// Generic provider interface to retrieve class level attributes
    /// </summary>
    /// <typeparam name="TType">The type</typeparam>
    /// <typeparam name="TAttribute">The attribute type</typeparam>
    internal class AttributeProvider<TType, TAttribute> : IAttributeProvider<TType, TAttribute>
        where TAttribute : Attribute
    {
        private readonly TAttribute[] _attributes;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeProvider{TType, TAttribute}"/> class.
        /// </summary>
        /// <param name="inherit">true to search the inheritance chain to find the attributes; otherwise, false</param>
        public AttributeProvider(bool inherit)
        {
            var attributes = (TAttribute[])typeof(TType)
                .GetCustomAttributes(typeof(TAttribute), inherit);

            _attributes = attributes;

            Count = attributes.Length;
            
            Attribute = attributes.FirstOrDefault();
        }

        /// <summary>
        /// The number of attributes
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// The first attribute
        /// </summary>
        public TAttribute Attribute { get; }

        /// <summary>
        /// All attributes
        /// </summary>
        /// <returns></returns>
        public IList<TAttribute> GetAttributes()
        {
            var attributes = _attributes
                .ToList();

            return attributes;
        }
    }
}
