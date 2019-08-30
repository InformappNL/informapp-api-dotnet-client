using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Values;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Values.TestValues;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.Tests.Values
{
    internal class TestValuesV1Example : IExample
    {
        private readonly IApiClient<TestValuesV1Request, TestValuesV1Response> _client;

        public TestValuesV1Example(
            IApiClient<TestValuesV1Request, TestValuesV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        public async Task Run(CancellationToken cancellationToken)
        {
            var request = CreateRequest();

            var response = await _client
                .Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(WebApiClientSampleProjectSettings.ConfigureAwait);

            var comparer = new TestValuesV1Comparer();

            bool equals = comparer.Equals(request, response.Model);

            if (equals == false)
            {
                throw new InvalidOperationException("Request values do not match response values!");
            }
        }

        private static TestValuesV1Request CreateRequest()
        {
            var request = new TestValuesV1Request
            {
                Boolean = true,
                Byte = 7,
                Char = 'F',
                DateTime = DateTime.UtcNow,
                DateTimeOffset = DateTimeOffset.Now,
                Decimal = 123.456M,
                Double = 123.456D,
                Enum = ValuesKind.Three,
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
                Bytes = new byte[] { 1, 2, 3},
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
