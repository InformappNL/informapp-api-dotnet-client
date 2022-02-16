using Informapp.InformSystem.IntegrationTool.Core.Loggers;
using Informapp.InformSystem.WebApi.Client.Decorators;

namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Debug factory decorator
    /// </summary>
    public class DebugFactoryDecorator<TCommand, TResult> : Decorator<IFactory<TCommand, TResult>>,
        IFactory<TCommand, TResult>

        where TCommand : class
        where TResult : class
    {
        private readonly IFactory<TCommand, TResult> _factory;

        private readonly IApplicationLogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DebugFactoryDecorator{TCommand, TResult}"/> class.
        /// </summary>
        public DebugFactoryDecorator(
            IFactory<TCommand, TResult> factory,
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
        /// <param name="command">The command</param>
        public TResult Create(TCommand command)
        {
            bool enabled = _logger.IsDebugEnabled;

            string commandName = string.Empty;
            string productName = string.Empty;

            if (enabled)
            {
                commandName = typeof(TCommand).Name;
                productName = typeof(TResult).Name;
            }

            if (enabled)
            {
                _logger.DebugFormat(
                    "Creating {0} from {1} \r\n{2}",
                    productName,
                    commandName,
                    _logger.Serialize(command));
            }

            var created = _factory.Create(command);

            if (enabled)
            {
                _logger.DebugFormat(
                    "Created {0} from {1} :\r\n{2}",
                    productName,
                    commandName,
                    _logger.Serialize(created));
            }

            return created;
        }
    }
}
