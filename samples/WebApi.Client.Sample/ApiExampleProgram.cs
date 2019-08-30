using Autofac;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.AppGroupMembers;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.AppGroups;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.BusinessGroupCredits;
using Informapp.InformSystem.WebApi.Client.Sample.Examples.BusinessGroups;
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
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample
{
    internal class ApiExampleProgram : ApiExampleProgramBase
    {
        public ApiExampleProgram(ILifetimeScope container) : base(container)
        {
            Argument.NotNull(container, nameof(container));
        }

        public async Task Start()
        {
            await Run<ApiClientExample>(true);
            await Run<ApiClientFactoryExample>(true);
            await Run<DependencyInjectionExample>(true);
            await Run<RestSharpExample>(true);

            await Run<OAuth2TokenV1Example>(true);
            await Run<EnvironmentOAuth2TokenV1Example>(true);
            await Run<OAuth2TokenV2Example>(false);

            await Run<PingV1Example>(true);

            await Run<GetValuesV1Example>(true);
            await Run<TestValuesV1Example>(true);

            await Run<DownloadTestFileV1Example>(true);
            await Run<UploadTestFileV1Example>(true);

            await Run<CreateAppGroupV1Example>(false);
            await Run<DeleteAppGroupV1Example>(false);
            await Run<EditAppGroupV1Example>(false);
            await Run<GetAppGroupV1Example>(true);
            await Run<ListAppGroupV1Example>(true);

            await Run<AddAppGroupMemberV1Example>(false);
            await Run<ListAppGroupMemberV1Example>(true);
            await Run<RemoveAppGroupMemberV1Example>(false);

            await Run<ListBusinessGroupV1Example>(true);
            await Run<ListBusinessGroupCreditCreditV1Example>(true);

            await Run<ListCustomerV1Example>(true);

            await Run<ListFormV1Example>(true);

            await Run<ListFormRegistrationStatsV1Example>(true);

            await Run<ListFormRegistrationV1Example>(true);

            await Run<ListFormRegistrationEmailV1Example>(true);

            await Run<ListFormRegistrationDataV1Example>(true);
        }
    }
}
