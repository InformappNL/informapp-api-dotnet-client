namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Generic IFactory interface
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface IFactory<TCommand, TResult>
        where TCommand : class
        where TResult : class
    {
        /// <summary>
        /// Create factory instance for type TCommand
        /// </summary>
        /// <param name="command">The command</param>
        TResult Create(TCommand command);
    }
}
