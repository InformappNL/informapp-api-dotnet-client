using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Informapp.InformSystem.IntegrationTool.Core.Configurations
{
    /// <summary>
    /// Datasource configuration class
    /// </summary>
    public class DataSourceConfiguration
    {
        /// <summary>
        /// Data source enabled or disabled
        /// </summary>
        [Required]
        public bool? Enabled { get; set; } = false;

        /// <summary>
        /// The file for persistent data storage
        /// Application needs write and read access to this file
        /// This setting is required
        /// </summary>
        [Required]
        public string DataFile { get; set; } = ".\\data.json";

        /// <summary>
        /// The maximum amount of time since a file was last uploaded 
        /// When a file has not changed but was uploaded longer ago it is uploaded again, hopefully minimizing the effects when things went wrong 
        /// </summary>
        [Required]
        public TimeSpan MaxFileAge { get; set; } = TimeSpan.FromHours(12);

        /// <summary>
        /// The maximum amount of time in minutes since a hash was calculated and compared for a file 
        /// Primary way to detect changes to a file is to store and compare its size, creation time and lastwrite time 
        /// Unfortunately this is not a watertight way as a file can change without a change to its size. Furthermore Windows may not always update the lastwrite time 
        /// The hash for a file is also stored, to minimize system load the hash is only calculated and compared when the stored hash is older 
        /// </summary>
        [Required]
        public TimeSpan MaxFileHashAge { get; set; } = TimeSpan.FromHours(1);

        /// <summary>
        /// Data sources
        /// </summary>
        [Required]
        public IList<DataSourceConfigurationDataSource> DataSources { get; } = new List<DataSourceConfigurationDataSource>(4);
    }
}
