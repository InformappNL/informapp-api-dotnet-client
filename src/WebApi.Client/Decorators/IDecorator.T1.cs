
namespace Informapp.InformSystem.WebApi.Client.Decorators
{
    /// <summary>
    /// Generic Interface for decorators
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDecorator<out T> : IDecorator
        where T : class
    {
        /// <summary>
        /// The instance being decorated
        /// </summary>
        T Decorating { get; }
    }
}
