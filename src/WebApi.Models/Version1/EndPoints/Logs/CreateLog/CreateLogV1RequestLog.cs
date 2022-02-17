using ConnectedDevelopment.InformSystem.WebApi.Models.DataAnnotations;
using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Logs.CreateLog
{
    /// <summary>
    /// Create log
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class CreateLogV1RequestLog
    {
        /// <summary>
        /// Source
        /// </summary>
        [DataMember]
        [EnumValidation(typeof(LogV1Source))]
        [ExampleValue(LogV1Source.WebUI)]
        [Required]
        public LogV1Source? Source { get; set; }

        /// <summary>
        /// Create date
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetUtcNow)]
        [Required]
        public DateTimeOffset? CreateDate { get; set; }

        /// <summary>
        /// Thread
        /// </summary>
        [DataMember]
        [ExampleValue("1")]
        [MaxLength(LogV1Constants.RequestThreadLength)]
        public string Thread { get; set; }

        /// <summary>
        /// Log level
        /// </summary>
        [DataMember]
        [EnumValidation(typeof(LogV1Level))]
        [ExampleValue(LogV1Level.Error)]
        [Required]
        public LogV1Level? Level { get; set; }

        /// <summary>
        /// Log name
        /// </summary>
        [DataMember]
        [ExampleValue("Logger")]
        [MaxLength(LogV1Constants.RequestNameLength)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        [DataMember]
        [ExampleValue("Error executing request")]
        [MaxLength(LogV1Constants.RequestMessageLength)]
        [Required]
        public string Message { get; set; }

        /// <summary>
        /// Exception
        /// </summary>
        [DataMember]
        [ExampleValue("StackOverflowException")]
        [MaxLength(LogV1Constants.RequestExceptionLength)]
        public string Exception { get; set; }
    }
}
