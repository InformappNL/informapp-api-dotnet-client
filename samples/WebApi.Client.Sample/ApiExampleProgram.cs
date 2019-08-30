using Autofac;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.AppGroupMembers;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.AppGroups;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.Clients;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.Customers;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.FormRegistrationData;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.FormRegistrationEmails;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.FormRegistrations;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.FormRegistrationStats;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.Forms;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.OAuth2;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.Pings;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.Tests.Files;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.Tests.Values;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample
{
    internal class ApiExampleProgram : ApiExampleProgramBase
    {
        public ApiExampleProgram(ILifetimeScope container) : base(container)
        {
            Argument.NotNull(container, nameof(container));
        }

        public async Task Start(CancellationToken cancellationToken)
        {
            var c = cancellationToken;

            var tasks = new[]
            {
                Run<ApiClientExample>(true, c),
                Run<ApiClientFactoryExample>(true, c),
                Run<DependencyInjectionExample>(true, c),
                Run<RestSharpExample>(true, c),

                Run<OAuth2TokenV1Example>(true, c),
                Run<EnvironmentOAuth2TokenV1Example>(true, c),
                Run<OAuth2TokenV2Example>(false, c),

                Run<PingV1Example>(true, c),

                Run<GetValuesV1Example>(true, c),
                Run<TestValuesV1Example>(true, c),

                Run<DownloadTestFileV1Example>(true, c),
                Run<UploadTestFileV1Example>(true, c),

                Run<CreateAppGroupV1Example>(false, c),
                Run<DeleteAppGroupV1Example>(false, c),
                Run<EditAppGroupV1Example>(false, c),
                Run<GetAppGroupV1Example>(true, c),
                Run<ListAppGroupV1Example>(true, c),

                Run<AddAppGroupMemberV1Example>(false, c),
                Run<ListAppGroupMemberV1Example>(true, c),
                Run<RemoveAppGroupMemberV1Example>(false, c),

                Run<ListCustomerV1Example>(true, c),

                Run<ListFormV1Example>(true, c),

                Run<ListFormRegistrationStatsV1Example>(true, c),

                Run<ListFormRegistrationV1Example>(true, c),

                Run<ListFormRegistrationEmailV1Example>(true, c),

                Run<ListFormRegistrationDataV1Example>(true, c),
            };

            foreach (var task in tasks)
            {
                await task.ConfigureAwait(WebApiClientSampleProjectSettings.ConfigureAwait);
            }
        }
    }
}
