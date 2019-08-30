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

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Values.TestBodyValues
{
    /// <summary>
    /// Test body values request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Put)]
    [Path(ValuesV1Constants.TestBodyRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public partial class TestBodyValuesV1Request : BaseRequest,
        IRequest<TestBodyValuesV1Response>
    {
        private const int StringMaxLength = 20;
        private const int UriMaxLength = 120;



        /// <summary>
        /// Integer (16 bits)
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue((short)16)]
        public short? Int16 { get; set; }

        /// <summary>
        /// Integer (32 bits)
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue(32)]
        public int? Int32 { get; set; }

        /// <summary>
        /// Integer (64 bits)
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue(64L)]
        public long? Int64 { get; set; }

        /// <summary>
        /// Unsigned integer (16 bits)
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue((ushort)16)]
        public ushort? UnsignedInt16 { get; set; }

        /// <summary>
        /// Unsigned integer (32 bits)
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue(32U)]
        public uint? UnsignedInt32 { get; set; }

        /// <summary>
        /// Unsigned integer (64 bits)
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue(64UL)]
        public ulong? UnsignedInt64 { get; set; }

        /// <summary>
        /// Byte
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue((byte)100)]
        public byte? Byte { get; set; }

        /// <summary>
        /// Signed byte
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue((sbyte)100)]
        public sbyte? SignedByte { get; set; }

        /// <summary>
        /// Char
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue('B')]
        public char? Char { get; set; }

        /// <summary>
        /// Uri
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleLocalizedUri(ValuesV1Constants.TestBodyRoute)]
        [MaxUriLength(UriMaxLength)]
        public Uri Uri { get; set; }

        /// <summary>
        /// Single
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue(100.11F)]
        public float? Single { get; set; }

        /// <summary>
        /// Double
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue(200.22D)]
        public double? Double { get; set; }

        /// <summary>
        /// Decimal
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleString(ExampleStringKind.Decimal, "100.123")]
        public decimal? Decimal { get; set; }

        /// <summary>
        /// String
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue("example string")]
        [MaxLength(StringMaxLength)]
        public string String { get; set; }

        /// <summary>
        /// Universally unique identifier (UUID)
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "9B1CE20F-AFA3-4AED-B82C-E69024F89F42")]
        public Guid? Uuid { get; set; }

        /// <summary>
        /// TimeSpan
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleString(ExampleStringKind.TimeSpan, "1.02:03:04.1234567")]
        public TimeSpan? TimeSpan { get; set; }

        /// <summary>
        /// DateTimeOffset
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? DateTimeOffset { get; set; }

        /// <summary>
        /// Boolean
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleValue(true)]
        public bool? Boolean { get; set; }

        /// <summary>
        /// Enum
        /// </summary>
        [BodyParameter]
        [DataMember]
        [EnumValidation(typeof(ValuesV1Kind))]
        [ExampleValue(ValuesV1Kind.Zero)]
        public ValuesV1Kind? Enum { get; set; }

        /// <summary>
        /// Array
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleCollection(ExampleCollectionKind.Array, new[] { 1, 2, 3 })]
        [MaxItems(3)]
        public IReadOnlyList<int> Array { get; set; }

        /// <summary>
        /// Bytes
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleCollection(ExampleCollectionKind.Array, new byte[] { 1, 2, 3 })]
        [MaxItems(3)]
        public byte[] Bytes { get; set; }

        /// <summary>
        /// Dictionary
        /// </summary>
        [BodyParameter]
        [DataMember]
        [ExampleMemberProvider(typeof(TestBodyValuesV1Request), nameof(Dictionary))]
        [MaxItems(3)]
        public IReadOnlyDictionary<int, int> Dictionary { get; set; }
    }
}
