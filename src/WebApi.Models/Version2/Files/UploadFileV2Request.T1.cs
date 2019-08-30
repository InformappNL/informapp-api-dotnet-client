using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Models.Version2.Files
{
    internal class UploadFileV2Request<T> : IUploadFileV2Request
        where T : class, IDisposable
    {
        private bool _isDisposed = false;

        private string _fileName;
        private Stream _file;

        public string FileName
        {
            get { return ThrowIfDisposed(_fileName); }
            set { _fileName = ThrowIfDisposed(value); }
        }

        public Stream File
        {
            get { return ThrowIfDisposed(_file); }
            set { _file = ThrowIfDisposed(value); }
        }

        public void Dispose()
        {
            if (_isDisposed == false)
            {
                if (_file != null)
                {
                    _file.Dispose();

                    _file = null;
                }

                _fileName = null;

                _isDisposed = true;
            }
        }

        private TValue ThrowIfDisposed<TValue>(TValue value)
        {
            if (_isDisposed == true)
            {
                throw new ObjectDisposedException(typeof(T).Name);
            }

            return value;
        }
    }
}
