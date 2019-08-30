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

            await Run<ApiClientExample>(true, c);
            await Run<ApiClientFactoryExample>(true, c);
            await Run<DependencyInjectionExample>(true, c);
            await Run<RestSharpExample>(true, c);

            await Run<OAuth2TokenV1Example>(true, c);
            await Run<EnvironmentOAuth2TokenV1Example>(true, c);
            await Run<OAuth2TokenV2Example>(false, c);

            await Run<PingV1Example>(true, c);

            await Run<GetValuesV1Example>(true, c);
            await Run<TestValuesV1Example>(true, c);

            await Run<DownloadTestFileV1Example>(true, c);
            await Run<UploadTestFileV1Example>(true, c);

            await Run<CreateAppGroupV1Example>(false, c);
            await Run<DeleteAppGroupV1Example>(false, c);
            await Run<EditAppGroupV1Example>(false, c);
            await Run<GetAppGroupV1Example>(true, c);
            await Run<ListAppGroupV1Example>(true, c);

            await Run<AddAppGroupMemberV1Example>(false, c);
            await Run<ListAppGroupMemberV1Example>(true, c);
            await Run<RemoveAppGroupMemberV1Example>(false, c);

            await Run<ListBusinessGroupV1Example>(true, c);
            await Run<ListBusinessGroupCreditCreditV1Example>(true, c);

            await Run<ListCustomerV1Example>(true, c);

            await Run<ListFormV1Example>(true, c);

            await Run<ListFormRegistrationStatsV1Example>(true, c);

            await Run<ListFormRegistrationV1Example>(true, c);

            await Run<ListFormRegistrationEmailV1Example>(true, c);

            await Run<ListFormRegistrationDataV1Example>(true, c);
        }
    }
}
