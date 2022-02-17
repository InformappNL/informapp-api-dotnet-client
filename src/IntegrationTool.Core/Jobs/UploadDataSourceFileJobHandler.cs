using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Commands;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Commands.UploadDataSourceFile;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Configurations;
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
    /// Upload datasource file hangfire job handler
    /// </summary>
    public class UploadDataSourceFileJobHandler : IJobHandler<UploadDataSourceFileJob>
    {
        private readonly ICommandHandler<UploadDataSourceFileCommand, UploadDataSourceFileCommandResult> _commandHandler;

        private readonly IOptions<DataSourceConfiguration> _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadDataSourceFileJobHandler"/> class.
        /// </summary>
        /// <param name="commandHandler">Injected command handler</param>
        /// <param name="configuration">Injected datasource configuration</param>
        public UploadDataSourceFileJobHandler(
            ICommandHandler<UploadDataSourceFileCommand, UploadDataSourceFileCommandResult> commandHandler,
            IOptions<DataSourceConfiguration> configuration)
        {
            Argument.NotNull(commandHandler, nameof(commandHandler));
            Argument.NotNull(configuration, nameof(configuration));

            _commandHandler = commandHandler;

            _configuration = configuration;
        }

        /// <summary>
        /// Execute upload datasource file hangfire job
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public async Task Execute(CancellationToken cancellationToken)
        {
            var exceptions = new List<Exception>(4);

            var configuration = _configuration.Value;

            Require.NotNull(configuration, nameof(configuration));

            if (configuration.Enabled != true)
            {
                return;
            }

            foreach (var dataSource in configuration.DataSources)
            {
                try
                {
                    if (dataSource.Enabled == true)
                    {
                        var uploadCommand = new UploadDataSourceFileCommand
                        {
                            Path = dataSource.File,
                            DataSourceId = dataSource.DataSourceId
                        };
                        _ = await _commandHandler
                            .Handle(uploadCommand, cancellationToken)
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
