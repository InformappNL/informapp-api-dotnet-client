using System.ComponentModel.DataAnnotations;

namespace Informapp.InformSystem.IntegrationTool.Core.Configurations
{
    /// <summary>
    /// Data context configuration class
    /// </summary>
    public class DataContextConfiguration
    {
        /// <summary>
        /// The file for persistent data storage
        /// Application needs write and read access to this file
        /// This setting is required
        /// </summary>
        [Required]
        public string File { get; set; } = ".\\data.json";
    }
}
