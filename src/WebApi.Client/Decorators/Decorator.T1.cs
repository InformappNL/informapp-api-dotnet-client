namespace Informapp.InformSystem.WebApi.Client.Decorators
{
    /// <summary>
    /// Generic class for decorators
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Decorator<T> : IDecorator<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Decorator{T}"/> class.
        /// </summary>
        /// <param name="decorated">The instance being decorated</param>
        public Decorator(T decorated)
        {
            Decorating = decorated;
        }

        /// <summary>
        /// The instance being decorated
        /// </summary>
        public T Decorating { get; }
    }
}
