﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Models.Version1.Files
{
    /// <summary>
    /// Upload file request
    /// </summary>
    public interface IUploadFileV1Request : IDisposable
    {
        /// <summary>
        /// File name
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// File
        /// </summary>
        Stream File { get; set; }
    }
}
