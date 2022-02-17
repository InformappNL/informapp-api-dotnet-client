
namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Factory interceptor abstraction
    /// </summary>
    /// <typeparam name="T">The type of object</typeparam>
    public interface IFactoryInterceptor<T>
    {
        /// <summary>
        /// Intercept the created instance
        /// </summary>
        /// <param name="result">The created instance</param>
        void Created(T result);
    }
}
