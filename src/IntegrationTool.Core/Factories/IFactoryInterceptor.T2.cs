
namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Factory interceptor abstraction
    /// </summary>
    /// <typeparam name="TCommand">The type of command</typeparam>
    /// <typeparam name="TResult">The type of object to create</typeparam>
    public interface IFactoryInterceptor<TCommand, TResult>
        where TCommand : class
        where TResult : class
    {
        /// <summary>
        /// Intercept the creation
        /// </summary>
        /// <param name="command"></param>
        void Creating(TCommand command);

        /// <summary>
        /// Intercept the created instance
        /// </summary>
        /// <param name="command"></param>
        /// <param name="result"></param>
        void Created(TCommand command, TResult result);
    }
}
