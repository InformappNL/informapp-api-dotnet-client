using System;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Sorting
{
    /// <summary>
    /// Mark enum type as sort values
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum, AllowMultiple = false)]
    public sealed class SortEnumAttribute : Attribute
    {

    }
}
