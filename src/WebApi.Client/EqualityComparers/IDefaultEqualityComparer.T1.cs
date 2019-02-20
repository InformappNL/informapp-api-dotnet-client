using System.Collections.Generic;

namespace Informapp.InformSystem.WebApi.Client.EqualityComparers
{
    /// <summary>
    /// Generic interface for default equality comparer
    /// </summary>
    /// <typeparam name="T">The type of objects to compar</typeparam>
    public interface IDefaultEqualityComparer<T> : IEqualityComparer<T>
    {

    }
}
