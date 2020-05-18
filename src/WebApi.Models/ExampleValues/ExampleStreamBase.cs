using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Remoting;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Models.ExampleValues
{
    /// <summary>
    /// Base class for example stream, everything throws NotImplementedException to ensure nothing of base class Stream is used.
    /// </summary>
    internal abstract class ExampleStreamBase : Stream,
        IDisposable
    {
        private const string ObsoleteMessage = "Do not use";

        protected ExampleStreamBase() : base()
        {

        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [Obsolete(ObsoleteMessage, error: true)]
        public override bool CanRead => throw new NotImplementedException();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [Obsolete(ObsoleteMessage, error: true)]
        public override bool CanSeek => throw new NotImplementedException();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [Obsolete(ObsoleteMessage, error: true)]
        public override bool CanWrite => throw new NotImplementedException();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [Obsolete(ObsoleteMessage, error: true)]
        public override long Length => throw new NotImplementedException();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [Obsolete(ObsoleteMessage, error: true)]
        public override long Position
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        [Obsolete(ObsoleteMessage, error: true)]
        public override void Flush()
        {
            throw new NotImplementedException();
        }

        [Obsolete(ObsoleteMessage, error: true)]
        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }

        [Obsolete(ObsoleteMessage, error: true)]
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        [Obsolete(ObsoleteMessage, error: true)]
        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        [Obsolete(ObsoleteMessage, error: true)]
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }

        [Obsolete(ObsoleteMessage, error: true)]
        public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [Obsolete(ObsoleteMessage, error: true)]
        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        [Obsolete(ObsoleteMessage, error: true)]
        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [Obsolete(ObsoleteMessage, error: true)]
        public override bool CanTimeout => throw new NotImplementedException();

        [Obsolete(ObsoleteMessage, error: true)]
        public override void Close()
        {
            throw new NotImplementedException();
        }

        [Obsolete(ObsoleteMessage, error: true)]
        public override ObjRef CreateObjRef(Type requestedType)
        {
            throw new NotImplementedException();
        }

        [Obsolete(ObsoleteMessage, error: true)]
        public override int EndRead(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        [Obsolete(ObsoleteMessage, error: true)]
        public override void EndWrite(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        [Obsolete(ObsoleteMessage, error: true)]
        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        [Obsolete(ObsoleteMessage, error: true)]
        public override Task FlushAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [Obsolete(ObsoleteMessage, error: true)]
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        [Obsolete(ObsoleteMessage, error: true)]
        public override object InitializeLifetimeService()
        {
            throw new NotImplementedException();
        }

        [Obsolete(ObsoleteMessage, error: true)]
        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [Obsolete(ObsoleteMessage, error: true)]
        public override int ReadByte()
        {
            throw new NotImplementedException();
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [Obsolete(ObsoleteMessage, error: true)]
        public override int ReadTimeout
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        [Obsolete(ObsoleteMessage, error: true)]
        public override string ToString()
        {
            throw new NotImplementedException();
        }

        [Obsolete(ObsoleteMessage, error: true)]
        public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [Obsolete(ObsoleteMessage, error: true)]
        public override void WriteByte(byte value)
        {
            throw new NotImplementedException();
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [Obsolete(ObsoleteMessage, error: true)]
        public override int WriteTimeout
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        [Obsolete(ObsoleteMessage, error: true)]
        protected override WaitHandle CreateWaitHandle()
        {
            throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        [Obsolete(ObsoleteMessage, error: true)]
        protected override void ObjectInvariant()
        {
            throw new NotImplementedException();
        }
    }
}
