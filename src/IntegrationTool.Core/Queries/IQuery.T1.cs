
namespace Informapp.InformSystem.IntegrationTool.Core.Queries
{
    /// <summary>
    /// Generic query interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
#pragma warning disable CA1040 // Avoid empty interfaces
    public interface IQuery<T>
#pragma warning restore CA1040 // Avoid empty interfaces
        where T : class
    {

    }
}
