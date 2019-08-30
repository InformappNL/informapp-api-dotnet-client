﻿using Informapp.InformSystem.WebApi.Client.Arguments;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Requires;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version2.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Files
{
    /// <summary>
    /// Upload file mapper class for version 2 upload requests
    /// </summary>
    /// <typeparam name="TRequest">The type of request</typeparam>
    /// <typeparam name="TResponse">The type of response</typeparam>
    public class UploadFileV2Mapper<TRequest, TResponse> : IUploadFileMapper<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        private readonly bool _mappable = typeof(IUploadFileV2Request).IsAssignableFrom(typeof(TRequest));

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFileV2Mapper{TRequest, TResponse}"/> class.
        /// </summary>
        public UploadFileV2Mapper()
        {

        }

        /// <summary>
        /// Map upload file to the request
        /// </summary>
        /// <param name="request">The request</param>
        /// <returns>true if the upload file was converted successfully mapped to the request; otherwise, false.</returns>
        public bool Map(ApiRequest<TRequest> request)
        {
            Argument.NotNull(request, nameof(request));

            bool mapped = false;

            if (_mappable == true)
            {
                if (request.UploadFile == null)
                {
                    request.UploadFile = new ApiUploadFileRequest();
                }

                var model = request.Model as IUploadFileV2Request;

                Require.NotNull(model, nameof(model));

                request.UploadFile.File = model.File;
                request.UploadFile.FileName = model.FileName;

                mapped = true;
            }

            return mapped;
        }
    }
}
