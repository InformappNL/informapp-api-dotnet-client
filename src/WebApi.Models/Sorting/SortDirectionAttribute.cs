using System;

namespace Informapp.InformSystem.WebApi.Models.Sorting
{
    /// <summary>
    /// Set sort direction
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class SortDirectionAttribute : Attribute
    {
        /// <summary>
        /// Direction
        /// </summary>
        public SortDirection Direction { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SortDirectionAttribute"/> class.
        /// </summary>
        public SortDirectionAttribute(SortDirection direction)
        {
            switch (direction)
            {
                case SortDirection.Asc:
                    break;
                case SortDirection.Desc:
                    break;
                default:
                    throw new ArgumentException("Invalid value", nameof(direction));
            }

            Direction = direction;
        }
    }
}
