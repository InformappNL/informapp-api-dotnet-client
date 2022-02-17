using ConnectedDevelopment.InformSystem.WebApi.Models.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Configuration
{
    /// <summary>
    /// API configuration class
    /// </summary>
    public class ApiConfiguration
    {
        /// <summary>
        /// The endpoint
        /// </summary>
        [AbsoluteUri]
        [Required]
        public Uri Endpoint { get; set; }

        /// <summary>
        /// The username
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// The password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
