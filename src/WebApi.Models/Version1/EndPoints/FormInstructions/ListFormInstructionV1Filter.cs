using Informapp.InformSystem.WebApi.Models.DataAnnotations;
using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.Filters;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormInstructions
{
    /// <summary>
    /// List form instruction request filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListFormInstructionV1Filter
    {
        /// <summary>
        /// Creation date
        /// </summary>
        [DataMember]
        public DateTimeOffsetV1Filter CreationDate { get; set; }

        /// <summary>
        /// Publish date
        /// </summary>
        [DataMember]
        public DateTimeOffsetV1Filter PublishDate { get; set; }

        /// <summary>
        /// Information date
        /// </summary>
        [DataMember]
        public DateTimeOffsetV1Filter InformationDate { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [DataMember]
        [EnumValidation(typeof(FormInstructionV1Status))]
        [ExampleValue(FormInstructionV1Status.Completed)]
        public FormInstructionV1Status? Status { get; set; }
    }
}
