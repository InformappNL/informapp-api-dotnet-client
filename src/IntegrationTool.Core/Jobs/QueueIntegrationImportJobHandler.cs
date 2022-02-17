using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Configurations;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.IntegrationImports;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Requires;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Resources;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Jobs
{
    /// <summary>
    /// Queue integration import job handler
    /// </summary>
    public class QueueIntegrationImportJobHandler : IJobHandler<QueueIntegrationImportJob>
    {
        private readonly IQueueIntegrationImportCommandHandler _commandHandler;

        private readonly IOptions<IntegrationImportConfiguration> _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueIntegrationImportJobHandler"/> class.
        /// </summary>
        /// <param name="commandHandler">Command handler</param>
        /// <param name="configuration">Configuration</param>
        public QueueIntegrationImportJobHandler(
            IQueueIntegrationImportCommandHandler commandHandler,
            IOptions<IntegrationImportConfiguration> configuration)
        {
            Argument.NotNull(commandHandler, nameof(commandHandler));
            Argument.NotNull(configuration, nameof(configuration));

            _commandHandler = commandHandler;

            _configuration = configuration;
        }

        /// <summary>
        /// Execute job
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task Execute(CancellationToken cancellationToken)
        {
            var exceptions = new List<Exception>(4);

            var configuration = _configuration.Value;

            Require.NotNull(configuration, nameof(configuration));

            if (configuration.Enabled != true)
            {
                return;
            }

            foreach (var integrationImport in configuration.IntegrationImports)
            {
                try
                {
                    if (integrationImport.Enabled == true)
                    {
                        var command = new QueueIntegrationImportCommand
                        {
                            IntegrationId = integrationImport.IntegrationId,
                            File = integrationImport.File,
                            MoveFile = integrationImport.MoveFile,
                        };

                        _ = await _commandHandler
                            .Handle(command, cancellationToken)
                            .ConfigureAwait(Await.Default);
                    }
                }
#pragma warning disable CA1031 // Do not catch general exception types
                catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
                {
                    exceptions.Add(ex);
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(ExceptionResource.AggregateJobException, exceptions);
            }
        }
    }
}
