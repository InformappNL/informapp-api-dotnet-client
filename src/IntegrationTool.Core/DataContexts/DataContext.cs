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
    /// Data context class
    /// </summary>
    public class DataContext : IDataContext,
        IDisposable
    {
        private const int BufferSize = 1024 * 16;

        private readonly Encoding _encoding = Encoding.UTF8;

        private Stream _stream;

        private DataModel _model;

        private bool _open;

        private readonly IOptions<DataSourceConfiguration> _configuration;

        private readonly IPath _path;

        private readonly IDirectoryCreator _directoryCreator;

        private readonly IFileInfoFactory _fileInfoFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext"/> class
        /// </summary>
        /// <param name="configuration">Injected datasource configuration</param>
        /// <param name="path">Injected file path provider</param>
        /// <param name="directoryCreator">Injected directory creator</param>
        /// <param name="fileInfoFactory">file info factory</param>
        public DataContext(
            IOptions<DataSourceConfiguration> configuration,
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

        /// <summary>
        /// Open file 
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public async Task Open(CancellationToken cancellationToken)
        {
            if (_open == false)
            {
                string path = _configuration.Value.DataFile;

                string dir = _path.GetDirectoryName(path);

                if (string.IsNullOrEmpty(dir) == false)
                {
                    await _directoryCreator
                        .CreateDirectoryAsync(dir, cancellationToken)
                        .ConfigureAwait(Await.Default);
                }

                var fileInfo = _fileInfoFactory.FromFileName(path);

                _stream = fileInfo.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);

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

                    if (model.Files == null)
                    {
                        model.Files = new List<FileModel>();
                    }

                    _model = model;
                }

                _open = true;
            }
        }

        private void ThrowIfNotOpen()
        {
            if (_open == false)
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// List of file models
        /// </summary>
        public IList<FileModel> Files
        {
            get
            {
                ThrowIfNotOpen();

                return _model.Files;
            }
        }

        /// <summary>
        /// Save changes to data context
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public async Task SaveChanges(CancellationToken cancellationToken)
        {
            ThrowIfNotOpen();

            _stream.Position = 0;
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

        /// <summary>
        /// Set dispose boolean to true
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
