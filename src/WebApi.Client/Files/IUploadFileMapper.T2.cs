using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Files
{
    /// <summary>
    /// Upload file mapper interface
    /// </summary>
    /// <typeparam name="TRequest">The type of request</typeparam>
    /// <typeparam name="TResponse">The type of response</typeparam>
    public interface IUploadFileMapper<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        /// <summary>
        /// Map upload file to the request
        /// </summary>
        /// <param name="request">The request</param>
        /// <returns>true if the upload file was converted successfully mapped to the request; otherwise, false.</returns>
        bool Map(ApiRequest<TRequest> request);
    }
}
