﻿using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Commands;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Commands.WriteFileFromStreams;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Configurations;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.DataContexts;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Enums;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Providers;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Queries;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Queries.HashFile;
using ConnectedDevelopment.InformSystem.WebApi.Client.DateTimeProviders;
using Microsoft.Extensions.Options;
using System;
using System.Globalization;
using System.IO;
using System.IO.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.IntegrationImports
{
    /// <summary>
    /// Queue integration import command handler
    /// </summary>
    public class QueueIntegrationImportCommandHandler : IQueueIntegrationImportCommandHandler
    {
        private readonly IDataContext _dataContext;

        private readonly IFileInfoFactory _fileInfoFactory;

        private readonly IQueryHandler<HashFileQuery, HashFileQueryResult> _queryHandler;

        private readonly ICommandHandler<WriteFileFromStreamCommand, WriteFileFromStreamCommandResult> _commandHandler;

        private readonly IPath _path;

        private readonly IGuidProvider _guidProvider;

        private readonly IDateTimeProvider _dateTimeProvider;

        private readonly IOptions<IntegrationImportConfiguration> _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueIntegrationImportCommandHandler"/> class.
        /// </summary>
        public QueueIntegrationImportCommandHandler(
            IDataContext dataContext,
            IFileInfoFactory fileInfoFactory,
            IQueryHandler<HashFileQuery, HashFileQueryResult> queryHandler,
            ICommandHandler<WriteFileFromStreamCommand, WriteFileFromStreamCommandResult> commandHandler,
            IPath path,
            IGuidProvider guidProvider,
            IDateTimeProvider dateTimeProvider,
            IOptions<IntegrationImportConfiguration> configuration)
        {
            _dataContext = dataContext;

            _fileInfoFactory = fileInfoFactory;

            _queryHandler = queryHandler;

            _commandHandler = commandHandler;

            _path = path;

            _guidProvider = guidProvider;

            _dateTimeProvider = dateTimeProvider;

            _configuration = configuration;
        }

        /// <summary>
        /// Handle the command
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The command result</returns>
        public async Task<QueueIntegrationImportCommandResult> Handle(
            QueueIntegrationImportCommand command,
            CancellationToken cancellationToken)
        {
            Argument.NotNull(command, nameof(command));

            var commandResult = new QueueIntegrationImportCommandResult();

            if (_dataContext.IntegrationImports.TryGetValue(command.IntegrationId, out var integrationImport) == false)
            {
                integrationImport = new IntegrationImport
                {
                    IntegrationId = command.IntegrationId,
                };

                _dataContext.IntegrationImports.Add(command.IntegrationId, integrationImport);
            }

            var fileInfo = _fileInfoFactory.FromFileName(command.File);

            if (fileInfo.Exists)
            {
                var versionId = _guidProvider.NewGuid();

                string extension = fileInfo.Extension;

                var now = _dateTimeProvider.UtcNow;

                string queueFolder = _configuration.Value.QueueFolder;

                string orignalFileName = fileInfo.Name;

                var fileDate = new DateTimeOffset(fileInfo.LastWriteTimeUtc, TimeSpan.Zero);

                string fileName = string.Format(
                    CultureInfo.InvariantCulture,
                    "{0}_{1:yyyyMMddHHmmssfff}_{2}{3}",
                    command.IntegrationId,
                    now,
                    versionId,
                    extension);

                var filePath = _path.Combine(queueFolder, fileName);

                long size = fileInfo.Length;

                if (command.MoveFile == true)
                {
                    fileInfo.MoveTo(filePath);

                    var queueItem = new IntegrationImportQueueItem
                    {
                        IntegrationId = command.IntegrationId,
                        File = filePath,
                        FileName = orignalFileName,
                        FileSize = size,
                        FileDate = fileDate,
                        Hash = null,
                        FileVersionId = versionId,
                    };

                    _dataContext.IntegrationImportQueue.Add(queueItem);
                }
                else
                {
                    using (var stream = fileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        var query = new HashFileQuery
                        {
                            File = stream
                        };

                        var queryResult = await _queryHandler
                            .Handle(query, cancellationToken)
                            .ConfigureAwait(Await.Default);

                        _ = stream.Seek(0, SeekOrigin.Begin);

                        if (string.Equals(integrationImport.Hash, queryResult.Hash, StringComparison.Ordinal) == false)
                        {
                            integrationImport.Hash = queryResult.Hash;
                            integrationImport.Size = size;

                            var writeCommand = new WriteFileFromStreamCommand
                            {
                                Path = queueFolder,
                                FileName = fileName,
                                File = stream,
                                Size = size
                            };

                            var writeCommandResult = await _commandHandler
                                .Handle(writeCommand, cancellationToken)
                                .ConfigureAwait(Await.Default);

                            switch (writeCommandResult.Result)
                            {
                                case WriteFileFromStreamCommandResultKind.Success:
                                    break;
                                default:
                                    throw UnexpectedEnumValueException.Create(writeCommandResult.Result);
                            }

                            string hash = queryResult.Hash;

                            var queueItem = new IntegrationImportQueueItem
                            {
                                IntegrationId = command.IntegrationId,
                                File = filePath,
                                FileName = orignalFileName,
                                FileSize = size,
                                FileDate = fileDate,
                                Hash = hash,
                                FileVersionId = versionId,
                            };

                            _dataContext.IntegrationImportQueue.Add(queueItem);
                        }
                    }
                }
            }

            return commandResult;
        }
    }
}
