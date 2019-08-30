using Informapp.InformSystem.WebApi.Models.DataAnnotations;
using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Values.TestQueryValues
{
    /// <summary>
    /// Test query values response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public partial class TestQueryValuesV1Response : BaseResponse
    {
        private const int StringMaxLength = 20;


        /// <summary>
        /// Integer (16 bits)
        /// </summary>
        [DataMember]
        [ExampleValue((short)16)]
        public short? Int16 { get; set; }

        /// <summary>
        /// Integer (32 bits)
        /// </summary>
        [DataMember]
        [ExampleValue(32)]
        public int? Int32 { get; set; }

        /// <summary>
        /// Integer (64 bits)
        /// </summary>
        [DataMember]
        [ExampleValue(64L)]
        public long? Int64 { get; set; }

        /// <summary>
        /// Unsigned integer (16 bits)
        /// </summary>
        [DataMember]
        [ExampleValue((ushort)16)]
        public ushort? UnsignedInt16 { get; set; }

        /// <summary>
        /// Unsigned integer (32 bits)
        /// </summary>
        [DataMember]
        [ExampleValue(32U)]
        public uint? UnsignedInt32 { get; set; }

        /// <summary>
        /// Unsigned integer (64 bits)
        /// </summary>
        [DataMember]
        [ExampleValue(64UL)]
        public ulong? UnsignedInt64 { get; set; }

        /// <summary>
        /// Byte
        /// </summary>
        [DataMember]
        [ExampleValue((byte)100)]
        public byte? Byte { get; set; }

        /// <summary>
        /// Signed byte
        /// </summary>
        [DataMember]
        [ExampleValue((sbyte)100)]
        public sbyte? SignedByte { get; set; }

        /// <summary>
        /// Char
        /// </summary>
        [DataMember]
        [ExampleValue('B')]
        public char? Char { get; set; }

        /// <summary>
        /// Uri
        /// </summary>
        [DataMember]
        [ExampleLocalizedUri(ValuesV1Constants.TestBodyRoute)]
        public Uri Uri { get; set; }

        /// <summary>
        /// Single
        /// </summary>
        [DataMember]
        [ExampleValue(100.11F)]
        public float? Single { get; set; }

        /// <summary>
        /// Double
        /// </summary>
        [DataMember]
        [ExampleValue(200.22D)]
        public double? Double { get; set; }

        /// <summary>
        /// Decimal
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Decimal, "100.123")]
        public decimal? Decimal { get; set; }

        /// <summary>
        /// String
        /// </summary>
        [DataMember]
        [ExampleValue("example string")]
        [MaxLength(StringMaxLength)]
        public string String { get; set; }

        /// <summary>
        /// Universally unique identifier (UUID)
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "9B1CE20F-AFA3-4AED-B82C-E69024F89F42")]
        public Guid? Uuid { get; set; }

        /// <summary>
        /// TimeSpan
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.TimeSpan, "1.02:03:04.1234567")]
        public TimeSpan? TimeSpan { get; set; }

        /// <summary>
        /// DateTimeOffset
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? DateTimeOffset { get; set; }

        /// <summary>
        /// Boolean
        /// </summary>
        [DataMember]
        [ExampleValue(true)]
        public bool? Boolean { get; set; }

        /// <summary>
        /// Enum
        /// </summary>
        [DataMember]
        [EnumValidation(typeof(ValuesV1Kind))]
        [ExampleValue(ValuesV1Kind.Zero)]
        public ValuesV1Kind? Enum { get; set; }

        /// <summary>
        /// Array
        /// </summary>
        [DataMember]
        [ExampleCollection(ExampleCollectionKind.List, new[] { 1, 2, 3 })]
        public IReadOnlyList<int> Array { get; set; }

        /// <summary>
        /// Bytes
        /// </summary>
        [DataMember]
        [ExampleCollection(ExampleCollectionKind.Array, new byte[] { 1, 2, 3 })]
        public byte[] Bytes { get; set; }

        /// <summary>
        /// Dictionary
        /// </summary>
        [DataMember]
        [ExampleMemberProvider(typeof(TestQueryValuesV1Response), nameof(Dictionary))]
        public IReadOnlyDictionary<int, int> Dictionary { get; set; }
    }
}
