namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Generic IFactory interface
    /// </summary>
    public interface IFactory<T>
    {
        /// <summary>
        /// Create factory instance of type T
        /// </summary>
        T Create();
    }
}
