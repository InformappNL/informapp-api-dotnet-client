using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Models.Version2.Files
{
    internal static class DownloadFileV2Response
    {
        public static IDownloadFileV2Response Create<T>()
            where T : class, IDisposable
        {
            return new DownloadFileV2Response<T>();
        }

        public static IDownloadFileV2Response Create<T>(T response)
            where T : class, IDisposable
        {
            return new DownloadFileV2Response<T>();
        }
    }
}
