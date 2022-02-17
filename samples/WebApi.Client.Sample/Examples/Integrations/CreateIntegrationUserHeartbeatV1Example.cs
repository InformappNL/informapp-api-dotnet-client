using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Examples.Integrations
{
    /// <summary>
    /// Example for create integration user heartbeat
    /// </summary>
    public class CreateIntegrationUserHeartbeatV1Example : IExample
    {
        private readonly IApiClient<CreateIntegrationUserHeartbeatV1Request, CreateIntegrationUserHeartbeatV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateIntegrationUserHeartbeatV1Example"/> class.
        /// </summary>
        public CreateIntegrationUserHeartbeatV1Example(
            IApiClient<CreateIntegrationUserHeartbeatV1Request, CreateIntegrationUserHeartbeatV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        /// <summary>
        /// Execute example
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task</returns>
        public async Task Execute(CancellationToken cancellationToken)
        {
            var datasources = new[]
            {
                Guid.Parse("677AE2E3-8A43-434C-B7DA-5D6698267C07"),
                Guid.Parse("345BD4F0-83C3-4D37-B9AA-6E5A04AC5A0E")
            }
            .Select(x => new CreateIntegrationUserHeartbeatV1RequestDataSource
            {
                DataSourceId = x
            })
            .ToList();

            var integrations = new[]
            {
                Guid.Parse("42B7748E-598C-42AF-BD4E-704C9D1C51FE"),
                Guid.Parse("BB23B49E-C78D-4807-B97E-FDFB47AEBA39")
            }
            .Select(x => new CreateIntegrationUserHeartbeatV1RequestIntegration
            {
                IntegrationId = x
            })
            .ToList();

            var assembly = typeof(WebApiClientSampleProject).Assembly;

            var driveInfo = new DriveInfo(assembly.Location);

            var drives = new[]
            {
                new CreateIntegrationUserHeartbeatV1RequestDrive
                {
                    Path = driveInfo.Name,
                    AvailableFreeSpace = driveInfo.AvailableFreeSpace,
                    TotalFreeSpace = driveInfo.TotalFreeSpace,
                    TotalSize = driveInfo.TotalSize,
                },
            };

            var request = new CreateIntegrationUserHeartbeatV1Request
            {
                Configuration = "todo",
                Version = "1.0.0.0",

                Drives = drives,

                DataSourceEnabled = false,
                DataSources = datasources,

                IntegrationEnabled = true,
                IntegrationDefaultEnabled = false,
                Integrations = integrations,
            };

            var response = await _client
                .Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
