using System.ComponentModel.DataAnnotations;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Queries.CreateStreamFromPath
{
    /// <summary>
    /// Query to initiate making a stream from a file
    /// </summary>
    public class CreateStreamFromPathQuery : IQuery<CreateStreamFromPathQueryResult>
    {
        /// <summary>
        /// Path of the file
        /// </summary>
        [Required]
        public string Path { get; set; }
    }
}
