using ConnectedDevelopment.InformSystem.WebApi.Models.DataAnnotations;
using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationData.ListFormRegistrationData
{
    /// <summary>
    /// Form registration data element
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListFormRegistrationDataV1ResponseElement
    {
        /// <summary>
        /// Form registration data element Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "9CDAF736-D3AC-4426-BE8E-4230A96BF1C5")]
        [Required]
        public Guid? FormRegistrationDataElementId { get; set; }

        /// <summary>
        /// Form registration Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "DFEEFE89-5E78-4BCF-BD8A-6686AE80AFD5")]
        public Guid? FormRegistrationId { get; set; }

        /// <summary>
        /// Parent form registration data element Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "FF733E74-244D-4E83-BDA7-A6476AFD4665")]
        public Guid? ParentFormRegistrationDataElementId { get; set; }

        /// <summary>
        /// Depth of the element within a form registration, starting at one.
        /// </summary>
        [DataMember]
        [ExampleValue(FormRegistrationDataV1Constants.MinDepth)]
        [Range(FormRegistrationDataV1Constants.MinDepth, FormRegistrationDataV1Constants.MaxDepth)]
        public int? Depth { get; set; }

        /// <summary>
        /// Zero based index of the element when the parent element is of kind array.
        /// </summary>
        [DataMember]
        [ExampleValue(FormRegistrationDataV1Constants.MinIndex)]
        [Range(FormRegistrationDataV1Constants.MinIndex, FormRegistrationDataV1Constants.MaxIndex)]
        public int? Index { get; set; }

        /// <summary>
        /// Order of the element within a form registration, starting at zero.
        /// 
        /// Order is unique within a form registration.
        /// </summary>
        [DataMember]
        [ExampleValue(FormRegistrationDataV1Constants.MinOrder)]
        [Range(FormRegistrationDataV1Constants.MinOrder, FormRegistrationDataV1Constants.MaxOrder)]
        public int? Order { get; set; }

        /// <summary>
        /// Kind of element
        /// </summary>
        [DataMember]
        [EnumValidation(typeof(FormRegistrationDataV1Kind))]
        [ExampleValue(FormRegistrationDataV1Kind.Dictionary)]
        public FormRegistrationDataV1Kind? Kind { get; set; }

        /// <summary>
        /// Name of the element
        /// </summary>
        [DataMember]
        [ExampleValue("date")]
        [MaxLength(FormRegistrationDataV1Constants.ResponseNameLength)]
        public string Name { get; set; }

        /// <summary>
        /// FullName is a dot separated list of element names starting from the root of the tree to this element.
        /// 
        /// Arrays are represented with square brackets (i.e. []).
        /// 
        /// Fields that have been filled multiple times (e.g. fields on subforms, multi-select fields) will have the same fullname.
        /// </summary>
        [DataMember]
        [ExampleValue("image.pins[].data.date")]
        [MaxLength(FormRegistrationDataV1Constants.ResponseFullNameLength)]
        public string FullName { get; set; }

        /// <summary>
        /// Path is a dot separated list of element names starting from the root of the tree to this element.
        /// 
        /// Array items are represented with the index between square brackets (e.g. [1]).
        /// 
        /// Path is unique within a form registration.
        /// </summary>
        [DataMember]
        [ExampleValue("image.pins[1].data.date")]
        [MaxLength(FormRegistrationDataV1Constants.ResponsePathLength)]
        public string Path { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        [DataMember]
        public ListFormRegistrationDataV1ResponseValue Value { get; set; }
    }
}
