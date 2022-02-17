using ConnectedDevelopment.InformSystem.WebApi.Models.DataAnnotations;
using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Instructions.ListInstruction
{
    /// <summary>
    /// List form instruction request filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListInformAppFormInstructionV1Filter
    {
        /// <summary>
        /// Creation date min
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? CreationDateMin { get; set; }

        /// <summary>
        /// Creation date max
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? CreationDateMax { get; set; }

        /// <summary>
        /// Publish date min
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? PublishDateMin { get; set; }

        /// <summary>
        /// Publish date max
        /// </summary>
        [DataMember]
        [ExampleConstant(ExampleConstantKind.DateTimeOffsetNow)]
        public DateTimeOffset? PublishDateMax { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        [DataMember]
        [ExampleValue("Report")]
        public string Message { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [DataMember]
        [EnumValidation(typeof(InstructionV1Status))]
        [ExampleValue(InstructionV1Status.Completed)]
        public InstructionV1Status? Status { get; set; }
    }
}
