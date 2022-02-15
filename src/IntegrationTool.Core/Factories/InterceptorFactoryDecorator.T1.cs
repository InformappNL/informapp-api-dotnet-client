using Informapp.InformSystem.WebApi.Client.Decorators;
using System.Collections.Generic;

namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Interceptor factory decorator
    /// </summary>
    /// <typeparam name="T">The type of object to create</typeparam>
    public class InterceptorFactoryDecorator<T> : Decorator<IFactory<T>>,
        IFactory<T>
    {
        private readonly IFactory<T> _factory;

        private readonly IReadOnlyList<IFactoryInterceptor<T>> _interceptors;

        /// <summary>
        /// Initializes a new instance of the <see cref="InterceptorFactoryDecorator{T}"/> class.
        /// </summary>
        public InterceptorFactoryDecorator(
            IFactory<T> factory,
            IReadOnlyList<IFactoryInterceptor<T>> interceptors) : base(factory)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(interceptors, nameof(interceptors));

            _factory = factory;

            _interceptors = interceptors;
        }

        /// <summary>
        /// Create instance and execute the interceptors
        /// </summary>
        public T Create()
        {
            var result = _factory.Create();

            if (_interceptors.Count > 0)
            {
                foreach (var interceptor in _interceptors)
                {
                    interceptor.Created(result);
                }
            }

            return result;
        }
    }
}
