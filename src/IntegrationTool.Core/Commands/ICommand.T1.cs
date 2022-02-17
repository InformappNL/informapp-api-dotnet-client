namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Commands
{
    /// <summary>
    /// Generic ICommand interface
    /// </summary>
#pragma warning disable CA1040 // Avoid empty interfaces
    public interface ICommand<TResult>
#pragma warning restore CA1040 // Avoid empty interfaces
        where TResult : class
    {

    }
}
