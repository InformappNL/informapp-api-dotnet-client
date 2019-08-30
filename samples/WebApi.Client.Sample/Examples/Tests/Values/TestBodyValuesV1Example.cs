using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Values;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Values.TestBodyValues;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.Tests.Values
{
    internal class TestBodyValuesV1Example : IExample
    {
        private readonly TestBodyValuesV1Comparer _comparer = new TestBodyValuesV1Comparer();

        private readonly IApiClient<TestBodyValuesV1Request, TestBodyValuesV1Response> _client;

        public TestBodyValuesV1Example(
            IApiClient<TestBodyValuesV1Request, TestBodyValuesV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            var model = CreateRequest();

            var request = ApiRequest.Create(model);

            var response = await _client
                .Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            bool equals = _comparer.Equals(request.Model, response.Model);

            if (equals == false)
            {
                throw new InvalidOperationException("Request values do not match response values!");
            }
        }

        private static TestBodyValuesV1Request CreateRequest()
        {
            var request = new TestBodyValuesV1Request
            {
                Boolean = true,
                Byte = 7,
                Char = 'F',
                DateTimeOffset = DateTimeOffset.Now,
                Decimal = 123.456M,
                Double = 123.456D,
                Enum = ValuesV1Kind.Three,
                Int16 = 16,
                Int32 = 32,
                Int64 = 64,
                SignedByte = 8,
                Single = 123.456F,
                String = "abc123",
                TimeSpan = TimeSpan.FromSeconds(123),
                UnsignedInt16 = 16,
                UnsignedInt32 = 32,
                UnsignedInt64 = 64,
                Uri = new Uri("https://localhost:12345/Home/Index"),
                Uuid = Guid.NewGuid(),
                Array = new[] { 1, 2, 3 },
                Bytes = new byte[] { 1, 2, 3 },
                Dictionary = new Dictionary<int, int>
                    {
                        { 1, 10 },
                        { 2, 20 },
                        { 3, 30 },
                    },
            };

            return request;
        }
    }
}
