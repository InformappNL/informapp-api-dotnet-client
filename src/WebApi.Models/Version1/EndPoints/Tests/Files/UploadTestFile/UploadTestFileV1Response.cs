using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Files.UploadTestFile
{
    /// <summary>
    /// Upload test file response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class UploadTestFileV1Response : BaseResponse
    {
        /// <summary>
        /// Size
        /// </summary>
        [DataMember]
        [ExampleValue(7L)]
        [Required]
        public long? Size { get; set; }

        /// <summary>
        /// MD5 checksum
        /// </summary>
        [DataMember]
        [ExampleCollection(ExampleCollectionKind.Array, new byte[] { 26, 121, 164, 214, 13, 230, 113, 142, 142, 91, 50, 110, 51, 138, 229, 51 })]
        [Required]
        public byte[] MD5Checksum { get; set; }
    }
}
