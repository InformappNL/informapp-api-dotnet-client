using Informapp.InformSystem.WebApi.Client.Responses;
using RestSharp;

namespace Informapp.InformSystem.WebApi.Client.RestSharp.Responses
{
    /// <summary>
    /// RestSharp API response class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RestSharpApiResponse<T> : ApiResponse<T>
        where T : class
    {
        /// <summary>
        /// The RestSharp <see cref="IRestRequest"/> instance
        /// </summary>
        internal IRestRequest RestRequest { get; set; }

        /// <summary>
        /// The RestSharp <see cref="IRestResponse{T}"/> instance
        /// </summary>
        internal IRestResponse<T> RestResponse { get; set; }
    }
}
