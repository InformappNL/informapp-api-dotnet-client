using Autofac;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.AppGroupMembers;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.AppGroups;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.AppUsers;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.BusinessGroups;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.Clients;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.Customers;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.DataSources;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.FormRegistrationData;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.FormRegistrationEmails;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.FormRegistrations;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.FormRegistrationStats;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.Forms;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.Logs;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.OAuth2;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.Pings;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.Tests.Files;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.Tests.Values;
using System.Collections.Generic;
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
            var examples = GetExamples();

            foreach (var example in examples)
            {
                if (example.Execute == true)
                {
                    await example.Task
                        .Invoke(cancellationToken)
                        .ConfigureAwait(Await.Default);
                }
            }
        }

        private IEnumerable<ExampleExecutionModel> GetExamples()
        {
            // Set the examples to run, true to enable, false to disable
            var examples = new[]
            {
                Create<ApiClientExample>(true),
                Create<ApiClientFactoryExample>(true),
                Create<DependencyInjectionExample>(true),
                Create<RestSharpExample>(true),

                Create<OAuth2TokenV1Example>(true),
                Create<EnvironmentOAuth2TokenV1Example>(true),
                Create<OAuth2TokenV2Example>(false),

                Create<CreateLogV1Example>(true),

                Create<PingV1Example>(true),

                Create<ListValuesV1Example>(true),
                Create<TestBodyValuesV1Example>(true),
                Create<TestQueryValuesV1Example>(true),

                Create<DownloadTestFileV1Example>(true),
                Create<UploadTestFileV1Example>(true),

                Create<CreateAppGroupV1Example>(false),
                Create<DeleteAppGroupV1Example>(false),
                Create<EditAppGroupV1Example>(false),
                Create<GetAppGroupV1Example>(true),
                Create<ListAppGroupV1Example>(true),

                Create<CreateAppUserV1Example>(false),
                Create<DeleteAppUserV1Example>(false),
                Create<GetAppUserV1Example>(true),
                Create<ListAppUserV1Example>(true),

                Create<AddAppGroupMemberV1Example>(false),
                Create<ListAppGroupMemberV1Example>(true),
                Create<RemoveAppGroupMemberV1Example>(false),

                Create<ListBusinessGroupV1Example>(true),

                Create<ListCustomerV1Example>(true),

                Create<ListDataSourceV1Example>(true),
                Create<UploadDataSourceV1Example>(false),
                Create<DownloadDataSourceV1Example>(false),

                Create<ListFormV1Example>(true),

                Create<ListFormRegistrationStatsV1Example>(true),

                Create<ListFormRegistrationV1Example>(true),

                Create<ListFormRegistrationEmailV1Example>(true),

                Create<ListFormRegistrationDataForRegistrationV1Example>(true),
            };

            return examples;
        }
    }
}
