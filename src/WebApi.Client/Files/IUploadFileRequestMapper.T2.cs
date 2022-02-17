using ConnectedDevelopment.InformSystem.WebApi.Client.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Files
{
    /// <summary>
    /// Upload file request mapper interface
    /// </summary>
    /// <typeparam name="TRequest">The type of request</typeparam>
    /// <typeparam name="TResponse">The type of response</typeparam>
    public interface IUploadFileRequestMapper<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        /// <summary>
        /// Map upload file to the request
        /// </summary>
        /// <param name="request">The request</param>
        /// <returns>true if the upload file was successfully mapped to the request; otherwise, false.</returns>
        bool Map(ApiRequest<TRequest> request);
    }
}
