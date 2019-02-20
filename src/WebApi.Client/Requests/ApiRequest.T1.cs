using System.ComponentModel.DataAnnotations;

namespace Informapp.InformSystem.WebApi.Client.Requests
{
    /// <summary>
    /// Generic DTO class for API requests
    /// </summary>
    /// <typeparam name="T">Type of request</typeparam>
    public class ApiRequest<T> : ApiRequest
        where T : class
    {
        /// <summary>
        /// The model
        /// </summary>
        [Required]
        public T Model { get; set; }
    }
}
