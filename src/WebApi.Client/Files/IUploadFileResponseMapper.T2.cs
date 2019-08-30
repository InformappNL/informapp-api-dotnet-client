using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Models.Requests;

namespace Informapp.InformSystem.WebApi.Client.Files
{
    /// <summary>
    /// Upload file response mapper interface
    /// </summary>
    /// <typeparam name="TRequest">The type of request</typeparam>
    /// <typeparam name="TResponse">The type of response</typeparam>
    public interface IUploadFileResponseMapper<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        /// <summary>
        /// Map response to the upload file response
        /// </summary>
        /// <param name="response">The response</param>
        /// <returns>true if the source response was successfully mapped to the destination response; otherwise, false.</returns>
        bool Map(ApiResponse<TResponse> response);
    }
}
