﻿using System;
using System.IO;

namespace Informapp.InformSystem.WebApi.Models.Version1.Files
{
    internal class UploadFileV1Request<T> : IUploadFileV1Request
        where T : class, IDisposable
    {
        private bool _isDisposed;

        private Stream _file;

        public string ContentType { get; set; }

        public Stream File
        {
            get => ThrowIfDisposed(_file);
            set => _file = ThrowIfDisposed(value);
        }

        public string FileName { get; set; }

        public long? Size { get; set; }

        public void Dispose()
        {
            if (_isDisposed == false)
            {
                if (_file != null)
                {
                    _file.Dispose();

                    _file = null;
                }

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
