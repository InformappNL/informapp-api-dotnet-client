﻿using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Files
{
    /// <summary>
    /// Download file mapper interface
    /// </summary>
    /// <typeparam name="TRequest">The type of request</typeparam>
    /// <typeparam name="TResponse">The type of response</typeparam>
    public interface IDownloadFileMapper<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        /// <summary>
        /// Map download file to the response
        /// </summary>
        /// <param name="request">The request</param>
        /// <returns>true if the upload file was converted successfully mapped to the response; otherwise, false.</returns>
        bool Map(ApiResponse<TResponse> response);
    }
}