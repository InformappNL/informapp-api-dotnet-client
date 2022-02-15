using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Exports;
using Informapp.InformSystem.IntegrationTool.Core.Configurations;
using Informapp.InformSystem.IntegrationTool.Core.IntegrationExports;
using Informapp.InformSystem.IntegrationTool.Core.Requires;
using Informapp.InformSystem.IntegrationTool.Core.Resources;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Jobs
{
    /// <summary>
    /// Download integration export hangfire job handler
    /// </summary>
    public class DownloadIntegrationExportJobHandler : IJobHandler<DownloadIntegrationExportJob>
    {
        /// <summary>
        /// Request page size
        /// </summary>
        public const int PageSize = 10;
        /// <summary>
        /// Maximum number of loops
        /// </summary>
        public const int MaxLoops = 50;
        /// <summary>
        /// Maximum number of exceptions
        /// </summary>
        public const int MaxExceptionCount = 10;


        private readonly IApiClient<ListIntegrationExportQueuedForMeV1Request, ListIntegrationExportQueuedForMeV1Response> _apiClient;

        private readonly IDownloadIntegrationExportCommandHandler _commandHandler;

        private readonly IOptions<IntegrationConfiguration> _integrationConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadIntegrationExportJobHandler"/> class.
        /// </summary>
        /// <param name="apiClient">Injected api client</param>
        /// <param name="commandHandler">Injected command handler</param>
        /// <param name="integrationConfiguration">Injected integration configuration</param>
        public DownloadIntegrationExportJobHandler(
            IApiClient<ListIntegrationExportQueuedForMeV1Request, ListIntegrationExportQueuedForMeV1Response> apiClient,
            IDownloadIntegrationExportCommandHandler commandHandler,
            IOptions<IntegrationConfiguration> integrationConfiguration)
        {
            Argument.NotNull(apiClient, nameof(apiClient));
            Argument.NotNull(commandHandler, nameof(commandHandler));
            Argument.NotNull(integrationConfiguration, nameof(integrationConfiguration));

            _apiClient = apiClient;

            _commandHandler = commandHandler;

            _integrationConfiguration = integrationConfiguration;
        }

        /// <summary>
        /// Execute download integration export hangfire job
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public async Task Execute(CancellationToken cancellationToken)
        {
            int totalCount = PageSize;
            int loopCounter = 0;

            var exceptions = new List<Exception>(4);

            var configuration = _integrationConfiguration.Value;

            Require.NotNull(configuration, nameof(configuration));

            if (configuration.Enabled != true)
            {
                return;
            }

            while (totalCount > 0)
            {
                if (exceptions.Count >= MaxExceptionCount)
                {
                    break;
                }

                loopCounter++;

                if (loopCounter > MaxLoops)
                {
                    //break;
                    throw new InvalidOperationException("Maximum number of iteration in while loop reached.");
                }

                cancellationToken.ThrowIfCancellationRequested();

                var request = new ListIntegrationExportQueuedForMeV1Request
                {
                    PageNumber = 1,
                    PageSize = PageSize,
                };

                var response = await _apiClient
                    .Execute(request, cancellationToken)
                    .ThrowIfFailed()
                    .ConfigureAwait(Await.Default);

                if (response.Headers.TotalCount.HasValue)
                {
                    totalCount = response.Headers.TotalCount.Value - PageSize;
                }
                else
                {
                    break;
                }

                foreach (var export in response.Model.Exports)
                {
                    try
                    {
                        var command = new DownloadIntegrationExportCommand
                        {
                            IntegrationExportId = export.IntegrationExportId,
                            IntegrationId = export.IntegrationId,
                            FileName = export.FileName,

                            // Injected by decorator
                            IntegrationExportLogId = null,

                            Configuration = null,

                            Accept = null,
                        };

                        var commandResult = await _commandHandler
                            .Handle(command, cancellationToken)
                            .ConfigureAwait(Await.Default);
                    }
#pragma warning disable CA1031 // Do not catch general exception types
                    catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
                    {
                        exceptions.Add(ex);
                    }

                    if (exceptions.Count >= MaxExceptionCount)
                    {
                        break;
                    }
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(ExceptionResource.AggregateJobException, exceptions);
            }
        }
    }
}
