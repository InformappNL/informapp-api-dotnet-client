using System;
using System.IO;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Files
{
    internal class DownloadFileV1Response<T> : IDownloadFileV1Response
        where T : class, IDisposable
    {
        private Stream _file;

        public string ContentType { get; set; }

        public Stream File
        {
            get => ThrowIfDisposed(_file);
            set => _file = ThrowIfDisposed(value);
        }

        public string FileName { get; set; }

        public long? Size { get; set; }

        private TValue ThrowIfDisposed<TValue>(TValue value)
        {
            if (_isDisposed == true)
            {
                throw new ObjectDisposedException(typeof(T).Name);
            }

            return value;
        }

        #region IDisposable

        private bool _isDisposed;

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed == false)
            {
                if (disposing)
                {
                    if (_file != null)
                    {
                        _file.Dispose();

                        _file = null;
                    }
                }

                _isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);

            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
