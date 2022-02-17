using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Imports;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.IntegrationImports
{
    /// <summary>
    /// Decorator class for <see cref="IUploadIntegrationImportCommandHandler"/> to report status for an upload from integration import
    /// </summary>
    public class ReportUploadIntegrationImportDecorator : Decorator<IUploadIntegrationImportCommandHandler>,
        IUploadIntegrationImportCommandHandler
    {
        private const int ExceptionLength = IntegrationImportV1Constants.ExceptionLength;

        private readonly IUploadIntegrationImportCommandHandler _handler;

        private readonly IApiClient<ReportIntegrationImportV1Request, ReportIntegrationImportV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportUploadIntegrationImportDecorator"/> class.
        /// </summary>
        /// <param name="handler">Injected command handler</param>
        /// <param name="client">Injected api client</param>
        public ReportUploadIntegrationImportDecorator(
            IUploadIntegrationImportCommandHandler handler,
            IApiClient<ReportIntegrationImportV1Request, ReportIntegrationImportV1Response> client) : base(handler)
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
        public async Task<UploadIntegrationImportCommandResult> Handle(
            UploadIntegrationImportCommand command,
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

                if (exception.Length > ExceptionLength)
                {
                    exception = exception.Substring(0, ExceptionLength);
                }
            }

            var request = new ReportIntegrationImportV1Request
            {
                IntegrationImportId = command.IntegrationImportId,
                Result =
                    commandResult.Success == true ?
                    UploadIntegrationImportV1Result.Success :
                    UploadIntegrationImportV1Result.Failed,
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
