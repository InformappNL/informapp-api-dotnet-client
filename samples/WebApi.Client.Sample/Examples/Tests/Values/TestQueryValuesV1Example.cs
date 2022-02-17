using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Values;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Values.TestQueryValues;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Examples.Tests.Values
{
    /// <summary>
    /// Example for test query values
    /// </summary>
    public class TestQueryValuesV1Example : IExample
    {
        private readonly TestQueryValuesV1Comparer _comparer = new();

        private readonly IApiClient<TestQueryValuesV1Request, TestQueryValuesV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestQueryValuesV1Example"/> class.
        /// </summary>
        public TestQueryValuesV1Example(
            IApiClient<TestQueryValuesV1Request, TestQueryValuesV1Response> client)
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

        private static TestQueryValuesV1Request CreateRequest()
        {
            var request = new TestQueryValuesV1Request
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
                //Dictionary = new Dictionary<int, int>
                //    {
                //        { 1, 10 },
                //        { 2, 20 },
                //        { 3, 30 },
                //    },
            };

            return request;
        }
    }
}
