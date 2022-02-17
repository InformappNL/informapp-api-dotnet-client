using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Configurations;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.DataContexts;
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
    /// Upload integration import job handler
    /// </summary>
    public class UploadIntegrationImportJobHandler : IJobHandler<UploadIntegrationImportJob>
    {
        private readonly IUploadIntegrationImportCommandHandler _commandHandler;

        private readonly IOptions<IntegrationImportConfiguration> _configuration;

        private readonly IDataContext _dataContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadIntegrationImportJobHandler"/> class.
        /// </summary>
        /// <param name="commandHandler">Command handler</param>
        /// <param name="configuration">Configuration</param>
        /// <param name="dataContext">Data context</param>
        public UploadIntegrationImportJobHandler(
            IUploadIntegrationImportCommandHandler commandHandler,
            IOptions<IntegrationImportConfiguration> configuration,
            IDataContext dataContext)
        {
            Argument.NotNull(commandHandler, nameof(commandHandler));
            Argument.NotNull(configuration, nameof(configuration));
            Argument.NotNull(dataContext, nameof(dataContext));

            _commandHandler = commandHandler;

            _configuration = configuration;

            _dataContext = dataContext;
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

            var uploadedIntegrationImports = new List<IntegrationImportQueueItem>();

            foreach (var integrationImport in _dataContext.IntegrationImportQueue)
            {
                try
                {
                    var uploadCommand = new UploadIntegrationImportCommand
                    {
                        Item = integrationImport,
                    };

                    var commandResult = await _commandHandler
                        .Handle(uploadCommand, cancellationToken)
                        .ConfigureAwait(Await.Default);

                    if (commandResult.Success == true)
                    {
                        uploadedIntegrationImports.Add(integrationImport);
                    }
                }
#pragma warning disable CA1031 // Do not catch general exception types
                catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
                {
                    exceptions.Add(ex);
                }
            }

            if (uploadedIntegrationImports.Count > 0)
            {
                foreach (var integrationImport in uploadedIntegrationImports)
                {
                    _ = _dataContext.IntegrationImportQueue.Remove(integrationImport);
                }

                await _dataContext
                    .SaveChanges(cancellationToken)
                    .ConfigureAwait(Await.Default);
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(ExceptionResource.AggregateJobException, exceptions);
            }
        }
    }
}
