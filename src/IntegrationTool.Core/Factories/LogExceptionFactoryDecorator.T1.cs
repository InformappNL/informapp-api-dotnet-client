using Informapp.InformSystem.IntegrationTool.Core.Loggers;
using Informapp.InformSystem.WebApi.Client.Decorators;
using System;

namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    public class LogExceptionFactoryDecorator<T> : Decorator<IFactory<T>>,
        IFactory<T>
    {
        private readonly IFactory<T> _factory;

        private readonly IApplicationLogger _logger;

        public LogExceptionFactoryDecorator(
            IFactory<T> factory,
            IApplicationLogger logger) : base(factory)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(logger, nameof(logger));

            _factory = factory;

            _logger = logger;
        }

        public T Create()
        {
            if (_logger.IsErrorEnabled)
            {
                try
                {
                    return _factory.Create();
                }
                catch (Exception ex)
                {
                    string productName = typeof(T).Name;

                    _logger.DebugFormat(
                        ex,
                        "Error creating {0}",
                        productName);

                    throw;
                }
            }
            else
            {
                return _factory.Create();
            }
        }
    }
}
