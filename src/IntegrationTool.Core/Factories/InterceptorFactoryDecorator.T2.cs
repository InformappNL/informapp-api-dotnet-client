using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using System.Collections.Generic;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Interceptor factory decorator
    /// </summary>
    /// <typeparam name="TCommand">The type of command</typeparam>
    /// <typeparam name="TResult">The type of object to create</typeparam>
    public class InterceptorFactoryDecorator<TCommand, TResult> : Decorator<IFactory<TCommand, TResult>>,
        IFactory<TCommand, TResult>

        where TCommand : class
        where TResult : class
    {
        private readonly IFactory<TCommand, TResult> _factory;

        private readonly IReadOnlyList<IFactoryInterceptor<TCommand, TResult>> _interceptors;

        /// <summary>
        /// Initializes a new instance of the <see cref="InterceptorFactoryDecorator{TCommand, TResult}"/> class.
        /// </summary>
        public InterceptorFactoryDecorator(
            IFactory<TCommand, TResult> factory,
            IReadOnlyList<IFactoryInterceptor<TCommand, TResult>> interceptors) : base(factory)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(interceptors, nameof(interceptors));

            _factory = factory;

            _interceptors = interceptors;
        }

        /// <summary>
        /// Create instance and execute the interceptors
        /// </summary>
        public TResult Create(TCommand command)
        {
            if (_interceptors.Count > 0)
            {
                foreach (var interceptor in _interceptors)
                {
                    interceptor.Creating(command);
                }
            }

            var result = _factory.Create(command);

            if (_interceptors.Count > 0)
            {
                foreach (var interceptor in _interceptors)
                {
                    interceptor.Created(command, result);
                }
            }

            return result;
        }
    }
}
