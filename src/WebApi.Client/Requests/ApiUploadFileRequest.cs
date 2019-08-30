﻿using System.IO;

namespace Informapp.InformSystem.WebApi.Client.Requests
{
    /// <summary>
    /// Api upload file request
    /// </summary>
    public class ApiUploadFileRequest
    {
        /// <summary>
        /// Content-Type
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// File
        /// </summary>
        public Stream File { get; set; }

        /// <summary>
        /// File name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Size
        /// </summary>
        public long? Size { get; set; }

        /// <summary>
        /// The parameter name of the file in the api request
        /// </summary>
        public string ParameterName { get; set; }
    }
}
