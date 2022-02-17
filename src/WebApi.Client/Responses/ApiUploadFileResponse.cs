using ConnectedDevelopment.InformSystem.WebApi.Client.Cryptography;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Responses
{
    /// <summary>
    /// Api upload file response
    /// </summary>
    public class ApiUploadFileResponse
    {
        /// <summary>
        /// Algorithm
        /// </summary>
        public HashAlgorithmKind? Algorithm { get; set; }

        /// <summary>
        /// Hash
        /// </summary>
        public byte[] Hash { get; set; }

        /// <summary>
        /// Hash encoded in Base64
        /// </summary>
        public string HashBase64 { get; set; }

        /// <summary>
        /// Size
        /// </summary>
        public long? Size { get; set; }
    }
}
