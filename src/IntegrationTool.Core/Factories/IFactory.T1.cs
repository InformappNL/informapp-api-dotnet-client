namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Factory abstraction
    /// </summary>
    /// <typeparam name="T">The type of object to create</typeparam>
    public interface IFactory<T>
    {
        /// <summary>
        /// Create instance
        /// </summary>
        T Create();
    }
}
