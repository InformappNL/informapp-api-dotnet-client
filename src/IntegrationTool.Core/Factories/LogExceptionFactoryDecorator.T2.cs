﻿using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Loggers;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using System;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Log exception factory decorator
    /// </summary>
    public class LogExceptionFactoryDecorator<TCommand, TResult> : Decorator<IFactory<TCommand, TResult>>,
        IFactory<TCommand, TResult>

        where TCommand : class
        where TResult : class
    {
        private readonly IFactory<TCommand, TResult> _factory;

        private readonly IApplicationLogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogExceptionFactoryDecorator{TCommand, TResult}"/> class.
        /// </summary>
        public LogExceptionFactoryDecorator(
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
            if (_logger.IsErrorEnabled)
            {
                try
                {
                    return _factory.Create(command);
                }
                catch (Exception ex)
                {
                    string commandName = typeof(TCommand).Name;
                    string productName = typeof(TResult).Name;

                    _logger.ErrorFormat(
                        ex,
                        "Error creating {0} from {1} \r\n{2}",
                        productName,
                        commandName,
                        _logger.Serialize(command));

                    throw;
                }
            }
            else
            {
                return _factory.Create(command);
            }
        }
    }
}
