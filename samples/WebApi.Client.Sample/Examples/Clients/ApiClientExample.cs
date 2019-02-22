﻿using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Clients;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Values.GetValues;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.Clients
{
    /// <summary>
    /// Example using the api client facade
    /// </summary>
    internal class ApiClientExample : IExample
    {
        public ApiClientExample()
        {

        }

        public async Task Run()
        {
            var client = new ApiClient<GetValuesV1Request, GetValuesV1Response>();

            var request = ApiRequest.Create(new GetValuesV1Request());

            var response = await client.Execute(request)
                .ThrowIfFailed();
        }
    }
}
