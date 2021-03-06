﻿using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.IntegrationTool.Core.Resources;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Applications
{
    /// <summary>
    /// Single instance application decorator
    /// </summary>
    public class SingleInstanceApplicationDecorator : Decorator<IApplication>,
        IApplication
    {
        /// <summary>
        /// Mutax name
        /// </summary>
        public const string MutaxName = "IntegrationTool";

        private static readonly Mutex _mutex = new Mutex(false, MutaxName);

        private readonly IApplication _application;

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleInstanceApplicationDecorator"/> class.
        /// </summary>
        public SingleInstanceApplicationDecorator(
            IApplication application) : base(application)
        {
            Argument.NotNull(application, nameof(application));

            _application = application;
        }

        /// <summary>
        /// Run the application
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task to run</returns>
        public Task Run(CancellationToken cancellationToken)
        {
            if (_mutex.WaitOne(0, false) == false)
            {
                throw new InvalidOperationException(ExceptionResource.ProgramAlreadyRunning);
            }

            return _application.Run(cancellationToken);
        }
    }
}
