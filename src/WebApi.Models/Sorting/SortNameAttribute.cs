using System;

namespace Informapp.InformSystem.WebApi.Models.Sorting
{
    /// <summary>
    /// Set sort name
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class SortNameAttribute : Attribute
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SortNameAttribute"/> class.
        /// </summary>
        internal SortNameAttribute(
            string name)
        {
            if (string.IsNullOrEmpty(name) == true)
            {
                if (name == null)
                {
                    throw new ArgumentNullException(nameof(name));
                }

                throw new ArgumentException("Can not be empty", nameof(name));
            }

            Name = name;
        }
    }
}
