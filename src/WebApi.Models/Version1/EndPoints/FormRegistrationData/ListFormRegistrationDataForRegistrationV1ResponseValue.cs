using Informapp.InformSystem.WebApi.Models.DataAnnotations;
using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationData
{
    /// <summary>
    /// Form registration data value
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListFormRegistrationDataForRegistrationV1ResponseValue
    {
#pragma warning disable CA1720 // Identifier contains type name

        /// <summary>
        /// The text value as entered on the form
        /// </summary>
        [DataMember]
        [ExampleValue("John Doe")]
        [MaxLength(FormRegistrationDataV1Constants.ResponseTextLength)]
        public string Text { get; set; }

        /// <summary>
        /// Boolean
        /// </summary>
        [DataMember]
        [ExampleValue(true)]
        public bool? Boolean { get; set; }

        /// <summary>
        /// Integer
        /// </summary>
        [DataMember]
        [ExampleValue(7L)]
        public long? Integer { get; set; }

        /// <summary>
        /// Decimal
        /// </summary>
        [DataMember]
        [DecimalRange(
            FormRegistrationDataV1Constants.MinDecimalString,
            FormRegistrationDataV1Constants.MaxDecimalString)]
        [ExampleString(ExampleStringKind.Decimal, "7.5")]
        public decimal? Decimal { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetUtcNow)]
        public DateTimeOffset? Date { get; set; }

        /// <summary>
        /// Time
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.TimeSpanMaxValue)]
        public TimeSpan? Time { get; set; }

        /// <summary>
        /// Uuid
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "77D0A315-3C8B-4B2B-97E3-5A2038798474")]
        public Guid? Uuid { get; set; }

        /// <summary>
        /// Form registration attachment id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "4BE4F694-FC83-45BE-A936-060F1754F72A")]
        public Guid? FormRegistrationAttachmentId { get; set; }

#pragma warning restore CA1720 // Identifier contains type name
    }
}
