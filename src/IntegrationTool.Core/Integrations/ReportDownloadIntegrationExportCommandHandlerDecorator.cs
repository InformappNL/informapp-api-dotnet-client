﻿using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Exports;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Integrations
{
    /// <summary>
    /// Decorator class for <see cref="IDownloadIntegrationExportCommandHandler"/> to report status for a download from integration export
    /// </summary>
    public class ReportDownloadIntegrationExportCommandHandlerDecorator : Decorator<IDownloadIntegrationExportCommandHandler>,
        IDownloadIntegrationExportCommandHandler
    {
        private readonly IDownloadIntegrationExportCommandHandler _handler;

        private readonly IApiClient<ReportIntegrationExportV1Request, ReportIntegrationExportV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportDownloadIntegrationExportCommandHandlerDecorator"/> class.
        /// </summary>
        /// <param name="handler">Injected command handler</param>
        /// <param name="client">Injected api client</param>
        public ReportDownloadIntegrationExportCommandHandlerDecorator(
            IDownloadIntegrationExportCommandHandler handler,
            IApiClient<ReportIntegrationExportV1Request, ReportIntegrationExportV1Response> client) : base(handler)
        {
            _handler = handler;

            _client = client;
        }

        /// <summary>
        /// Report status back to api
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public async Task<DownloadIntegrationExportCommandResult> Handle(
            DownloadIntegrationExportCommand command,
            CancellationToken cancellationToken)
        {
            Argument.NotNull(command, nameof(command));

            var stopwatch = Stopwatch.StartNew();

            var commandResult = await _handler
                .Handle(command, cancellationToken)
                .ConfigureAwait(Await.Default);

            stopwatch.Stop();

            int duration = Convert(stopwatch.ElapsedMilliseconds);

            string exception = null;

            if (commandResult.Exception != null)
            {
                exception = commandResult.Exception.ToString();
            }

            var request = new ReportIntegrationExportV1Request
            {
                IntegrationExportId = command.IntegrationExportId,
                IntegrationExportLogId = command.IntegrationExportLogId,
                Result = commandResult.Success == true ? DownloadIntegrationExportV1Result.Success : DownloadIntegrationExportV1Result.Failed,
                Duration = duration,
                Message = commandResult.Message,
                Exception = exception,
            };

            _ = await _client
                .Execute(request, cancellationToken)
                .ConfigureAwait(Await.Default);

            return commandResult;
        }

        private static int Convert(long duration)
        {
            if (duration > int.MaxValue)
            {
                return int.MaxValue;
            }

            if (duration < int.MinValue)
            {
                return int.MinValue;
            }

            return (int)duration;
        }
    }
}
