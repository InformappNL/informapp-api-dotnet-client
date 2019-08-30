using System;

namespace Informapp.InformSystem.WebApi.Models.Version1.Files
{
    internal static class UploadFileV1Request
    {
        public static IUploadFileV1Request Create<T>()
            where T : class, IDisposable
        {
            return new UploadFileV1Request<T>();
        }

        public static IUploadFileV1Request Create<T>(T request)
            where T : class, IDisposable
        {
            _ = request;

            return new UploadFileV1Request<T>();
        }
    }
}
