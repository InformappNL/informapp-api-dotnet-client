namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Factory abstraction
    /// </summary>
    /// <typeparam name="TCommand">The type of command</typeparam>
    /// <typeparam name="TResult">The type of object to create</typeparam>
    public interface IFactory<TCommand, TResult>
        where TCommand : class
        where TResult : class
    {
        /// <summary>
        /// Create instance
        /// </summary>
        /// <param name="command">The command</param>
        TResult Create(TCommand command);
    }
}
