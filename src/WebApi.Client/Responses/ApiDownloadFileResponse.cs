using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Responses
{
    /// <summary>
    /// Api download file response
    /// </summary>
    public class ApiDownloadFileResponse
    {
        /// <summary>
        /// The file
        /// </summary>
        public Stream File { get; set; }

        /// <summary>
        /// The filename
        /// </summary>
        public string FileName { get; set; }
    }
}
