using Informapp.InformSystem.WebApi.Client.Arguments;
using Informapp.InformSystem.WebApi.Client.Responses;
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
    /// Download file mapper class for version 2 responses
    /// </summary>
    /// <typeparam name="TRequest">The type of request</typeparam>
    /// <typeparam name="TResponse">The type of response</typeparam>
    public class DownloadFileV2Mapper<TRequest, TResponse> : IDownloadFileMapper<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        private readonly bool _mappable = typeof(IDownloadFileV2Response).IsAssignableFrom(typeof(TResponse));

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadFileV2Mapper{TRequest, TResponse}"/> class.
        /// </summary>
        public DownloadFileV2Mapper()
        {

        }

        /// <summary>
        /// Map download file to the response
        /// </summary>
        /// <param name="request">The request</param>
        /// <returns>true if the upload file was converted successfully mapped to the response; otherwise, false.</returns>
        public bool Map(ApiResponse<TResponse> response)
        {
            Argument.NotNull(response, nameof(response));

            bool mapped = false;

            if (_mappable == true)
            {
                if (response.Model == null)
                {
                    response.Model = new TResponse();
                }

                if (response.ContentModel == null)
                {
                    response.ContentModel = response.Model;
                }

                var model = response.Model as IDownloadFileV2Response;

                model.File = response.DownloadFile.File;
                model.FileName = response.DownloadFile.FileName;

                mapped = true;
            }

            return mapped;
        }
    }
}
