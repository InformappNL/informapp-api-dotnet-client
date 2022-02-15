using Informapp.InformSystem.IntegrationTool.Core.Configurations;
using Informapp.InformSystem.IntegrationTool.Core.IO;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.DataContexts
{
    /// <summary>
    /// Data context implementation
    /// </summary>
    public class DataContext : IDataContext,
        IDisposable
    {
        private const int BufferSize = 1024 * 16;

        private readonly Encoding _encoding = Encoding.UTF8;

        private Stream _stream;

        private DataModel _model;

        private bool _open;

        private readonly IOptions<DataContextConfiguration> _configuration;

        private readonly IPath _path;

        private readonly IDirectoryCreator _directoryCreator;

        private readonly IFileInfoFactory _fileInfoFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext"/> class
        /// </summary>
        /// <param name="configuration">configuration</param>
        /// <param name="path">path</param>
        /// <param name="directoryCreator">directory creator</param>
        /// <param name="fileInfoFactory">file info factory</param>
        public DataContext(
            IOptions<DataContextConfiguration> configuration,
            IPath path,
            IDirectoryCreator directoryCreator,
            IFileInfoFactory fileInfoFactory)
        {
            Argument.NotNull(configuration, nameof(configuration));
            Argument.NotNull(path, nameof(path));
            Argument.NotNull(directoryCreator, nameof(directoryCreator));
            Argument.NotNull(fileInfoFactory, nameof(fileInfoFactory));

            _configuration = configuration;

            _path = path;

            _directoryCreator = directoryCreator;

            _fileInfoFactory = fileInfoFactory;
        }

        /// <inheritdoc/>
        public async Task Open(CancellationToken cancellationToken)
        {
            if (_open == false)
            {
                string path = _configuration.Value.File;

                string dir = _path.GetDirectoryName(path);

                if (string.IsNullOrEmpty(dir) == false)
                {
                    await _directoryCreator
                        .CreateDirectoryAsync(dir, cancellationToken)
                        .ConfigureAwait(Await.Default);
                }

                var fileInfo = _fileInfoFactory.FromFileName(path);

                _stream = fileInfo.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);

                await Load(cancellationToken)
                    .ConfigureAwait(Await.Default);

                _open = true;
            }
        }

        private async Task Load(CancellationToken cancellationToken)
        {
            _ = _stream.Seek(0, SeekOrigin.Begin);

            using (var reader = new StreamReader(_stream, _encoding, detectEncodingFromByteOrderMarks: false, BufferSize, leaveOpen: true))
            {
                string content = await reader
                    .ReadToEndAsync()
                    .ConfigureAwait(Await.Default);

                cancellationToken.ThrowIfCancellationRequested();

                DataModel model = null;

                try
                {
                    model = JsonConvert.DeserializeObject<DataModel>(content);
                }
                catch (JsonSerializationException)
                {
                    model = new DataModel();
                }

                if (model == null)
                {
                    model = new DataModel();
                }

                _model = model;
            }

            _ = _stream.Seek(0, SeekOrigin.Begin);
        }

        private void ThrowIfNotOpen()
        {
            if (_open == false)
            {
                throw new InvalidOperationException();
            }
        }

        /// <inheritdoc/>
        public IList<DataSource> DataSources
        {
            get
            {
                ThrowIfNotOpen();

                return _model.DataSources;
            }
        }

        /// <inheritdoc/>
        public IDictionary<Guid?, IntegrationImport> IntegrationImports
        {
            get
            {
                ThrowIfNotOpen();

                return _model.IntegrationImports;
            }
        }

        /// <inheritdoc/>
        public IList<IntegrationImportQueueItem> IntegrationImportQueue
        {
            get
            {
                ThrowIfNotOpen();

                return _model.IntegrationImportQueue;
            }
        }

        /// <inheritdoc/>
        public async Task SaveChanges(CancellationToken cancellationToken)
        {
            ThrowIfNotOpen();

            _ = _stream.Seek(0, SeekOrigin.Begin);
            _stream.SetLength(0);

            using (var writer = new StreamWriter(_stream, _encoding, BufferSize, leaveOpen: true))
            {
                string content = JsonConvert.SerializeObject(_model, Formatting.Indented);

                cancellationToken.ThrowIfCancellationRequested();

                await writer
                    .WriteAsync(content)
                    .ConfigureAwait(Await.Default);

                await writer
                    .FlushAsync()
                    .ConfigureAwait(Await.Default);
            }

            _ = _stream.Seek(0, SeekOrigin.Begin);
        }

        /// <inheritdoc/>
        public Task Rollback(CancellationToken cancellationToken)
        {
            ThrowIfNotOpen();

            return Load(cancellationToken);
        }

        #region IDisposable Support

        private bool disposed;

        /// <summary>
        /// Dispose stream is disposing is true
        /// </summary>
        /// <param name="disposing">Disposing boolean</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed == false)
            {
                if (disposing == true)
                {
                    if (_stream != null)
                    {
                        _stream.Dispose();
                    }
                }

                disposed = true;
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
