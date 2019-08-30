
namespace Informapp.InformSystem.WebApi.Models.Version2.Files
{
    /// <summary>
    /// Upload file response
    /// </summary>
    public interface IUploadFileV2Response
    {
        /// <summary>
        /// Algorithm
        /// </summary>
        FileV2HashAlgorithm? Algorithm { get; set; }

        /// <summary>
        /// Hash
        /// </summary>
        byte[] Hash { get; set; }

        /// <summary>
        /// Size
        /// </summary>
        long? Size { get; set; }
    }
}
