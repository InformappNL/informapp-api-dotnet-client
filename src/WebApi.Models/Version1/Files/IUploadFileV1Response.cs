
namespace Informapp.InformSystem.WebApi.Models.Version1.Files
{
    /// <summary>
    /// Upload file response
    /// </summary>
    public interface IUploadFileV1Response
    {
        /// <summary>
        /// Algorithm
        /// </summary>
        FileV1HashAlgorithm? Algorithm { get; set; }

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
