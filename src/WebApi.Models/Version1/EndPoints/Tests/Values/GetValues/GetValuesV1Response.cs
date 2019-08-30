using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Values.GetValues
{
    /// <summary>
    /// Values response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public partial class GetValuesV1Response : BaseResponse
    {
        /// <summary>
        /// Integer (16 bits) min value
        /// </summary>
        [DataMember]
        [ExampleValue(short.MinValue)]
        [Required]
        public short? Int16MinValue { get; set; } = short.MinValue;
        /// <summary>
        /// Integer (16 bits) max value
        /// </summary>
        [DataMember]
        [ExampleValue(short.MaxValue)]
        [Required]
        public short? Int16MaxValue { get; set; } = short.MaxValue;

        /// <summary>
        /// Integer (32 bits) min value
        /// </summary>
        [DataMember]
        [ExampleValue(int.MinValue)]
        [Required]
        public int? Int32MinValue { get; set; } = int.MinValue;
        /// <summary>
        /// Integer (32 bits) max value
        /// </summary>
        [DataMember]
        [ExampleValue(int.MaxValue)]
        [Required]
        public int? Int32MaxValue { get; set; } = int.MaxValue;

        /// <summary>
        /// Integer (64 bits) min value
        /// </summary>
        [DataMember]
        [ExampleValue(long.MinValue)]
        [Required]
        public long? Int64MinValue { get; set; } = long.MinValue;
        /// <summary>
        /// Integer (64 bits) max value
        /// </summary>
        [DataMember]
        [ExampleValue(long.MaxValue)]
        [Required]
        public long? Int64MaxValue { get; set; } = long.MaxValue;


        /// <summary>
        /// Unsigned integer (16 bits) max value
        /// </summary>
        [DataMember]
        [ExampleValue(ushort.MaxValue)]
        [Required]
        public ushort? UnsignedInt16MaxValue { get; set; } = ushort.MaxValue;

        /// <summary>
        /// Unsigned integer (32 bits) max value
        /// </summary>
        [DataMember]
        [ExampleValue(uint.MaxValue)]
        [Required]
        public uint? UnsignedInt32MaxValue { get; set; } = uint.MaxValue;

        /// <summary>
        /// Unsigned integer (64 bits) max value
        /// </summary>
        [DataMember]
        [ExampleValue(ulong.MaxValue)]
        [Required]
        public ulong? UnsignedInt64MaxValue { get; set; } = ulong.MaxValue;

        /// <summary>
        /// Byte max value
        /// </summary>
        [DataMember]
        [ExampleValue(byte.MaxValue)]
        [Required]
        public byte? ByteMaxValue { get; set; } = byte.MaxValue;

        /// <summary>
        /// Signed byte min value
        /// </summary>
        [DataMember]
        [ExampleValue(sbyte.MinValue)]
        [Required]
        public sbyte? SignedByteMinValue { get; set; } = sbyte.MinValue;
        /// <summary>
        /// Signed byte max value
        /// </summary>
        [DataMember]
        [ExampleValue(sbyte.MaxValue)]
        [Required]
        public sbyte? SignedByteMaxValue { get; set; } = sbyte.MaxValue;

        /// <summary>
        /// Char min value
        /// </summary>
        [DataMember]
        [ExampleValue(char.MinValue)]
        [Required]
        public char? CharMinValue { get; set; } = char.MinValue;
        /// <summary>
        /// Char max value
        /// </summary>
        [DataMember]
        [ExampleValue(char.MaxValue)]
        [Required]
        public char? CharMaxValue { get; set; } = char.MaxValue;
        
        /// <summary>
        /// Uri
        /// </summary>
        [DataMember]
        [ExampleLocalizedUri(ValuesV1Constants.GetRoute)]
        [Required]
        public Uri Uri { get; set; }

        /// <summary>
        /// Relative Uri
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.RelativeUri, ValuesV1Constants.GetRoute)]
        [Required]
        public Uri RelativeUri { get; set; } = new Uri(ValuesV1Constants.GetRoute, UriKind.Relative);

        /// <summary>
        /// Single min value
        /// </summary>
        [DataMember]
        [ExampleValue(float.MinValue)]
        [Required]
        public float? SingleMinValue { get; set; } = float.MinValue;
        /// <summary>
        /// Single max value
        /// </summary>
        [DataMember]
        [ExampleValue(float.MaxValue)]
        [Required]
        public float? SingleMaxValue { get; set; } = float.MaxValue;

        /// <summary>
        /// Double min value
        /// </summary>
        [DataMember]
        [ExampleValue(double.MinValue)]
        [Required]
        public double? DoubleMinValue { get; set; } = double.MinValue;
        /// <summary>
        /// Double max value
        /// </summary>
        [DataMember]
        [ExampleValue(double.MaxValue)]
        [Required]
        public double? DoubleMaxValue { get; set; } = double.MaxValue;

        /// <summary>
        /// Decimal min value
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DecimalMinValue)]
        [Required]
        public decimal? DecimalMinValue { get; set; } = decimal.MinValue;
        /// <summary>
        /// Decimal max value
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DecimalMaxValue)]
        [Required]
        public decimal? DecimalMaxValue { get; set; } = decimal.MaxValue;

        /// <summary>
        /// String
        /// </summary>
        [DataMember]
        [ExampleValue(_string)]
        [Required]
        public string String { get; set; } = _string;
        private const string _string = "string";

        /// <summary>
        /// Universally unique identifier (UUID)
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, _guid)]
        [Required]
        public Guid? Uuid { get; set; } = Guid.Parse(_guid);
        private const string _guid = "1D392741-8810-424A-895D-8D64B9DCA26C";

        /// <summary>
        /// TimeSpan min value
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.TimeSpanMinValue)]
        [Required]
        public TimeSpan? TimeSpanMinValue { get; set; } = TimeSpan.MinValue;
        /// <summary>
        /// TimeSpan max value
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.TimeSpanMaxValue)]
        [Required]
        public TimeSpan? TimeSpanMaxValue { get; set; } = TimeSpan.MaxValue;

        /// <summary>
        /// DateTime min value
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeMinValue)]
        [Required]
        public DateTime? DateTimeMinValue { get; set; } = DateTime.MinValue;
        /// <summary>
        /// DateTime max value
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeMaxValue)]
        [Required]
        public DateTime? DateTimeMaxValue { get; set; } = DateTime.MaxValue;

        /// <summary>
        /// DateTimeOffset min value
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetMinValue)]
        [Required]
        public DateTimeOffset? DateTimeOffsetMinValue { get; set; } = DateTimeOffset.MinValue;
        /// <summary>
        /// DateTimeOffset max value
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetMaxValue)]
        [Required]
        public DateTimeOffset? DateTimeOffsetMaxValue { get; set; } = DateTimeOffset.MaxValue;

        /// <summary>
        /// Boolean false value
        /// </summary>
        [DataMember]
        [ExampleValue(false)]
        [Required]
        public bool? BooleanFalse { get; set; } = false;
        /// <summary>
        /// Boolean true value
        /// </summary>
        [DataMember]
        [ExampleValue(true)]
        [Required]
        public bool? BooleanTrue { get; set; } = true;

        /// <summary>
        /// Enum
        /// </summary>
        [DataMember]
        [ExampleValue(ValuesKind.Zero)]
        [Required]
        public ValuesKind? Enum { get; set; } = ValuesKind.Zero;

        /// <summary>
        /// Array
        /// </summary>
        [DataMember]
        [ExampleCollection(ExampleCollectionKind.List, new[] { 1, 2, 3, })]
        [Required]
        public IEnumerable<int> Array { get; set; } = new[] { 1, 2, 3, };

        /// <summary>
        /// Dictionary
        /// </summary>
        [DataMember]
        [ExampleMemberProvider(typeof(GetValuesV1Response), nameof(Dictionary))]
        [Required]
        public IDictionary<int, int> Dictionary { get; set; }
            = new Dictionary<int, int> { { 1, 10 }, { 2, 20 }, { 3, 30 } };
    }
}
