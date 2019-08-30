using Informapp.InformSystem.WebApi.Models.DataAnnotations;
using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Http;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.Files;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Files.UploadTestFile
{
    /// <summary>
    /// Upload test file response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [UploadFileResponse]
    public class UploadTestFileV1Response : BaseResponse,
        IUploadFileV1Response
    {
        /// <summary>
        /// Algorithm
        /// </summary>
        [DataMember]
        [EnumValidation(typeof(FileV1HashAlgorithm))]
        [ExampleValue(FileV1HashAlgorithm.SHA512)]
        public FileV1HashAlgorithm? Algorithm { get; set; }

        /// <summary>
        /// Hash
        /// </summary>
        [DataMember]
        [ExampleCollection(ExampleCollectionKind.Array, new byte[]
        {
            059, 177, 046, 218, 060, 041, 141, 181,
            222, 037, 089, 127, 084, 217, 036, 242,
            225, 126, 120, 162, 106, 216, 149, 062,
            216, 033, 142, 230, 130, 240, 187, 190,
            144, 033, 226, 243, 000, 157, 021, 044,
            145, 027, 241, 242, 094, 198, 131, 169,
            002, 113, 065, 102, 118, 122, 251, 216,
            229, 189, 015, 176, 018, 078, 203, 138,
        })]
        public byte[] Hash { get; set; }

        /// <summary>
        /// Size
        /// </summary>
        [DataMember]
        [ExampleValue(7L)]
        [Required]
        public long? Size { get; set; }
    }
}
