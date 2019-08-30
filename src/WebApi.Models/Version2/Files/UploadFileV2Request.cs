using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Models.Version2.Files
{
    internal static class UploadFileV2Request
    {
        public static IUploadFileV2Request Create<T>()
            where T : class, IDisposable
        {
            return new UploadFileV2Request<T>();
        }

        public static IUploadFileV2Request Create<T>(T request)
            where T : class, IDisposable
        {
            return new UploadFileV2Request<T>();
        }
    }
}
