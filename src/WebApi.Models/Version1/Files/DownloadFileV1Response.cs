using System;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Files
{
    internal static class DownloadFileV1Response
    {
        public static IDownloadFileV1Response Create<T>()
            where T : class, IDisposable
        {
            return new DownloadFileV1Response<T>();
        }

        public static IDownloadFileV1Response Create<T>(T response)
            where T : class, IDisposable
        {
            _ = response;

            return new DownloadFileV1Response<T>();
        }
    }
}
