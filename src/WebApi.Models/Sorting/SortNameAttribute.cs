using ConnectedDevelopment.InformSystem.WebApi.Models.Arguments;
using System;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Sorting
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
        public SortNameAttribute(string name)
        {
            Argument.NotNullOrEmpty(name, nameof(name));

            Name = name;
        }
    }
}
