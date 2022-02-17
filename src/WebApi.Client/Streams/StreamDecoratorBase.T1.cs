using ConnectedDevelopment.InformSystem.WebApi.Client.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Streams
{
    internal abstract class StreamDecoratorBase<T> : Stream,
        IDecorator<Stream>,
        IEquatable<T>

        where T : StreamDecoratorBase<T>
    {
        public Stream Stream { get; }

        public Stream Decorating => Stream;

        protected StreamDecoratorBase(Stream stream)
        {
            Argument.NotNull(stream, nameof(stream));

            Stream = stream;
        }



        #region Stream

        public override long Position
        {
            get => Stream.Position;
            set => Stream.Position = value;
        }

        public override long Length => Stream.Length;

        public override bool CanWrite => Stream.CanWrite;

        public override bool CanTimeout => Stream.CanTimeout;

        public override bool CanSeek => Stream.CanSeek;

        public override bool CanRead => Stream.CanRead;

        public override int ReadTimeout
        {
            get => Stream.ReadTimeout;
            set => Stream.ReadTimeout = value;
        }

        public override int WriteTimeout
        {
            get => Stream.WriteTimeout;
            set => Stream.WriteTimeout = value;
        }



        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            return Stream.BeginRead(buffer, offset, count, callback, state);
        }

        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            return Stream.BeginWrite(buffer, offset, count, callback, state);
        }

        public override void Close()
        {
            Stream.Close();
        }

        //public void CopyTo(Stream destination);

        //public void CopyTo(Stream destination, int bufferSize);

        public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
        {
            return Stream.CopyToAsync(destination, bufferSize, cancellationToken);
        }

        //public Task CopyToAsync(Stream destination, int bufferSize);

        //public Task CopyToAsync(Stream destination);

        //public void Dispose();

        public override int EndRead(IAsyncResult asyncResult)
        {
            return Stream.EndRead(asyncResult);
        }

        public override void EndWrite(IAsyncResult asyncResult)
        {
            Stream.EndWrite(asyncResult);
        }

        public override void Flush()
        {
            Stream.Flush();
        }

        //public Task FlushAsync();

        public override Task FlushAsync(CancellationToken cancellationToken)
        {
            return Stream.FlushAsync(cancellationToken);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return Stream.Read(buffer, offset, count);
        }

        //public Task<int> ReadAsync(byte[] buffer, int offset, int count);

        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            return Stream.ReadAsync(buffer, offset, count, cancellationToken);
        }

        public override int ReadByte()
        {
            return Stream.ReadByte();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return Stream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            Stream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            Stream.Write(buffer, offset, count);
        }

        //public Task WriteAsync(byte[] buffer, int offset, int count);

        public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            return Stream.WriteAsync(buffer, offset, count, cancellationToken);
        }

        public override void WriteByte(byte value)
        {
            Stream.WriteByte(value);
        }

        //protected override WaitHandle CreateWaitHandle();

        private bool _isDisposed;

        protected override void Dispose(bool disposing)
        {
            if (_isDisposed == false)
            {
                if (disposing)
                {
                    Stream.Dispose();
                }

                _isDisposed = true;
            }

            base.Dispose(disposing);
        }

        //protected override void ObjectInvariant();

        #endregion



        #region MarshalByRefObject

        public override object InitializeLifetimeService()
        {
            return Stream.InitializeLifetimeService();
        }

        #endregion



        #region Object

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is T other)
            {
                return Equals(other);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Stream.GetHashCode();
        }

        public override string ToString()
        {
            return Stream.ToString();
        }

        #endregion



        #region IEquatable

        public abstract bool Equals(T other);

        #endregion
    }
}
