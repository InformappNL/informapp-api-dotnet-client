using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppGroupMembers.ListAppGroupMember;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.AppGroupMembers
{
    internal class ListAppGroupMemberV1Example : IExample
    {
        private readonly IApiClient<ListAppGroupMemberV1Request, ListAppGroupMemberV1Response> _client;

        public ListAppGroupMemberV1Example(
            IApiClient<ListAppGroupMemberV1Request, ListAppGroupMemberV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        public async Task Run(CancellationToken cancellationToken)
        {
            var request = new ListAppGroupMemberV1Request
            {
                Sort = new[] { ListAppGroupMemberV1Sort.CreateDate },
                PageNumber = 1,
                PageSize = 50
            };

            var response = await _client.Execute(request, cancellationToken)
                .ThrowIfFailed();
        }
    }
}
