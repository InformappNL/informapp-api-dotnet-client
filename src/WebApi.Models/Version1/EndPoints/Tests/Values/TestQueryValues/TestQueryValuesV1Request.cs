using Informapp.InformSystem.WebApi.Models.DataAnnotations;
using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Http;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Responses;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.Errors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Values.TestQueryValues
{
    /// <summary>
    /// Test query values request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Get)]
    [Path(ValuesV1Constants.TestQueryRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public partial class TestQueryValuesV1Request : BaseRequest,
        IRequest<TestQueryValuesV1Response>
    {
        private const int StringMaxLength = 20;
        private const int UriMaxLength = 120;



        /// <summary>
        /// Integer (16 bits)
        /// </summary>
        [DataMember]
        [ExampleValue((short)16)]
        [QueryParameter]
        public short? Int16 { get; set; }

        /// <summary>
        /// Integer (32 bits)
        /// </summary>
        [DataMember]
        [ExampleValue(32)]
        [QueryParameter]
        public int? Int32 { get; set; }

        /// <summary>
        /// Integer (64 bits)
        /// </summary>
        [DataMember]
        [ExampleValue(64L)]
        [QueryParameter]
        public long? Int64 { get; set; }

        /// <summary>
        /// Unsigned integer (16 bits)
        /// </summary>
        [DataMember]
        [ExampleValue((ushort)16)]
        [QueryParameter]
        public ushort? UnsignedInt16 { get; set; }

        /// <summary>
        /// Unsigned integer (32 bits)
        /// </summary>
        [DataMember]
        [ExampleValue(32U)]
        [QueryParameter]
        public uint? UnsignedInt32 { get; set; }

        /// <summary>
        /// Unsigned integer (64 bits)
        /// </summary>
        [DataMember]
        [ExampleValue(64UL)]
        [QueryParameter]
        public ulong? UnsignedInt64 { get; set; }

        /// <summary>
        /// Byte
        /// </summary>
        [DataMember]
        [ExampleValue((byte)100)]
        [QueryParameter]
        public byte? Byte { get; set; }

        /// <summary>
        /// Signed byte
        /// </summary>
        [DataMember]
        [ExampleValue((sbyte)100)]
        [QueryParameter]
        public sbyte? SignedByte { get; set; }

        /// <summary>
        /// Char
        /// </summary>
        [DataMember]
        [ExampleValue('B')]
        [QueryParameter]
        public char? Char { get; set; }

        /// <summary>
        /// Uri
        /// </summary>
        [DataMember]
        [ExampleLocalizedUri(ValuesV1Constants.TestBodyRoute)]
        [MaxUriLength(UriMaxLength)]
        [QueryParameter]
        public Uri Uri { get; set; }

        /// <summary>
        /// Single
        /// </summary>
        [DataMember]
        [ExampleValue(100.11F)]
        [QueryParameter]
        public float? Single { get; set; }

        /// <summary>
        /// Double
        /// </summary>
        [DataMember]
        [ExampleValue(200.22D)]
        [QueryParameter]
        public double? Double { get; set; }

        /// <summary>
        /// Decimal
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Decimal, "100.123")]
        [QueryParameter]
        public decimal? Decimal { get; set; }

        /// <summary>
        /// String
        /// </summary>
        [DataMember]
        [ExampleValue("example string")]
        [MaxLength(StringMaxLength)]
        [QueryParameter]
        public string String { get; set; }

        /// <summary>
        /// Universally unique identifier (UUID)
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "9B1CE20F-AFA3-4AED-B82C-E69024F89F42")]
        [QueryParameter]
        public Guid? Uuid { get; set; }

        /// <summary>
        /// TimeSpan
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.TimeSpan, "1.02:03:04.1234567")]
        [QueryParameter]
        public TimeSpan? TimeSpan { get; set; }

        /// <summary>
        /// DateTimeOffset
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        [QueryParameter]
        public DateTimeOffset? DateTimeOffset { get; set; }

        /// <summary>
        /// Boolean
        /// </summary>
        [DataMember]
        [ExampleValue(true)]
        [QueryParameter]
        public bool? Boolean { get; set; }

        /// <summary>
        /// Enum
        /// </summary>
        [DataMember]
        [EnumValidation(typeof(ValuesV1Kind))]
        [ExampleValue(ValuesV1Kind.Zero)]
        [QueryParameter]
        public ValuesV1Kind? Enum { get; set; }

        /// <summary>
        /// Array
        /// </summary>
        [DataMember]
        [ExampleCollection(ExampleCollectionKind.Array, new[] { 1, 2, 3 })]
        [MaxItems(3)]
        [QueryParameter]
        public IReadOnlyList<int> Array { get; set; }

        /// <summary>
        /// Bytes
        /// </summary>
        [DataMember]
        [ExampleCollection(ExampleCollectionKind.Array, new byte[] { 1, 2, 3 })]
        [MaxItems(3)]
        [QueryParameter]
        public byte[] Bytes { get; set; }

        /// <summary>
        /// Dictionary
        /// </summary>
        [DataMember]
        [ExampleMemberProvider(typeof(TestQueryValuesV1Request), nameof(Dictionary))]
        [MaxItems(3)]
        [QueryParameter]
        public IReadOnlyDictionary<int, int> Dictionary { get; set; }
    }
}
