using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormDataNames
{
    /// <summary>
    /// Form data name
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListFormDataNameV1ResponseFormDataName
    {
        /// <summary>
        /// Form data name Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "0AE1737C-D2F1-4F7C-8FBD-C9566ED719D5")]
        [Required]
        public Guid? FormDataNameId { get; set; }

        /// <summary>
        /// Parent form data name Id
        /// </summary>
        [DataMember]
        [ExampleString(ExampleStringKind.Guid, "FB63B708-CC7E-4097-8D8D-A21AA53D7A66")]
        public Guid? ParentFormDataNameId { get; set; }

        /// <summary>
        /// Depth of the data name, starting at one.
        /// </summary>
        [DataMember]
        [ExampleValue(FormDataNameV1Constants.MinDepth)]
        [Range(FormDataNameV1Constants.MinDepth, FormDataNameV1Constants.MaxDepth)]
        public int? Depth { get; set; }

        /// <summary>
        /// Indicates whether the data name is an array
        /// </summary>
        [DataMember]
        [ExampleValue(true)]
        public bool? IsArray { get; set; }

        /// <summary>
        /// The data name
        /// </summary>
        [DataMember]
        [ExampleValue("date")]
        [MaxLength(FormDataNameV1Constants.ResponseNameLength)]
        public string Name { get; set; }

        /// <summary>
        /// FullName is a dot separated list of data names starting from the root of the form to this dataname.
        /// 
        /// Arrays are represented with square brackets (i.e. []).
        /// </summary>
        [DataMember]
        [ExampleValue("image.pins[].data.date")]
        [MaxLength(FormDataNameV1Constants.ResponseFullNameLength)]
        public string FullName { get; set; }
    }
}
