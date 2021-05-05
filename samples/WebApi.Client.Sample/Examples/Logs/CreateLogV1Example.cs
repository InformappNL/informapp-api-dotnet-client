using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.DateTimeProviders;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Logs;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Logs.CreateLog;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.Logs
{
    /// <summary>
    /// Example for create log
    /// </summary>
    public class CreateLogV1Example : IExample
    {
        private readonly IApiClient<CreateLogV1Request, CreateLogV1Response> _client;

        private readonly IDateTimeProvider _dateTimeProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLogV1Example"/> class.
        /// </summary>
        public CreateLogV1Example(
            IApiClient<CreateLogV1Request, CreateLogV1Response> client,
            IDateTimeProvider dateTimeProvider)
        {
            Argument.NotNull(client, nameof(client));
            Argument.NotNull(dateTimeProvider, nameof(dateTimeProvider));

            _client = client;

            _dateTimeProvider = dateTimeProvider;
        }

        /// <summary>
        /// Execute example
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task</returns>
        public async Task Execute(CancellationToken cancellationToken)
        {
            var date = _dateTimeProvider.UtcNow;

            var logs = new[]
            {
                new CreateLogV1RequestLog
                {
                    Source = LogV1Source.WebUI,
                    CreateDate = date,
                    Thread = Thread.CurrentThread.Name ?? "main",
                    Level = LogV1Level.Info,
                    Name = nameof(CreateLogV1Example),
                    Message = "executing create log example",
                    Exception = null,
                },
            };

            var request = new CreateLogV1Request
            {
                Logs = logs,
            };

            var response = await _client
                .Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
