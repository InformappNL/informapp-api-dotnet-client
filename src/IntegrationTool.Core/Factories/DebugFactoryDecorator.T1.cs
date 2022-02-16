using Informapp.InformSystem.IntegrationTool.Core.Loggers;
using Informapp.InformSystem.WebApi.Client.Decorators;

namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Debug factory decorator
    /// </summary>
    public class DebugFactoryDecorator<T> : Decorator<IFactory<T>>,
        IFactory<T>
    {
        private readonly IFactory<T> _factory;

        private readonly IApplicationLogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DebugFactoryDecorator{T}"/> class.
        /// </summary>
        public DebugFactoryDecorator(
            IFactory<T> factory,
            IApplicationLogger logger) : base(factory)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(logger, nameof(logger));

            _factory = factory;

            _logger = logger;
        }

        /// <summary>
        /// Create instance
        /// </summary>
        public T Create()
        {
            var created = _factory.Create();

            if (_logger.IsDebugEnabled)
            {
                string productName = typeof(T).Name;

                _logger.DebugFormat(
                    "Created {0} :\r\n{1}",
                    productName,
                    _logger.Serialize(created));
            }

            return created;
        }
    }
}
