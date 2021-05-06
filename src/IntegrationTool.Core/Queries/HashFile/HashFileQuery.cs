using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Informapp.InformSystem.IntegrationTool.Core.Queries.HashFile
{
    /// <summary>
    /// Query to hash the provided file
    /// </summary>
    public class HashFileQuery : IQuery<HashFileQueryResult>
    {
        /// <summary>
        /// Stream of the file
        /// </summary>
        [Required]
        public Stream File { get; set; }
    }
}
