
namespace ConnectedDevelopment.InformSystem.WebApi.Client.Responses
{
    /// <summary>
    /// Generic DTO class for API response
    /// </summary>
    /// <typeparam name="T">The type of response</typeparam>
    public class ApiResponse<T> : ApiResponse
        where T : class
    {
        /// <summary>
        /// The model
        /// </summary>
        public T Model { get; set; }
    }
}
