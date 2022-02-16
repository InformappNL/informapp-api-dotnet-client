using Informapp.InformSystem.IntegrationTool.Core.Configurations;
using Informapp.InformSystem.WebApi.Client.Decorators;
using Microsoft.Extensions.Options;
using System.IO.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.IntegrationImports
{
    /// <summary>
    /// Decorator class for <see cref="IUploadIntegrationImportCommandHandler"/> to move file after upload
    /// </summary>
    public class MoveFileUploadIntegrationImportDecorator : Decorator<IUploadIntegrationImportCommandHandler>,
        IUploadIntegrationImportCommandHandler
    {
        private readonly IUploadIntegrationImportCommandHandler _handler;

        private readonly IOptions<IntegrationImportConfiguration> _configuration;

        private readonly IFileInfoFactory _factory;

        private readonly IPath _path;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateUploadIntegrationImportDecorator"/> class.
        /// </summary>
        /// <param name="handler">decorated command handler</param>
        /// <param name="configuration">configuration</param>
        /// <param name="factory">factory</param>
        /// <param name="path">path</param>
        public MoveFileUploadIntegrationImportDecorator(
            IUploadIntegrationImportCommandHandler handler,
            IOptions<IntegrationImportConfiguration> configuration,
            IFileInfoFactory factory,
            IPath path) : base(handler)
        {
            Argument.NotNull(handler, nameof(handler));
            Argument.NotNull(configuration, nameof(configuration));
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(path, nameof(path));

            _handler = handler;

            _configuration = configuration;

            _factory = factory;

            _path = path;
        }

        /// <summary>
        /// Execute upload and move file after
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public async Task<UploadIntegrationImportCommandResult> Handle(
            UploadIntegrationImportCommand command,
            CancellationToken cancellationToken)
        {
            Argument.NotNull(command, nameof(command));

            var commandResult = await _handler
                .Handle(command, cancellationToken)
                .ConfigureAwait(Await.Default);

            if (commandResult.Success == true)
            {
                var configuration = _configuration.Value;

                string doneFolder = configuration.DoneFolder;

                string sourceFile = command.Item.File;

                var sourceFileInfo = _factory.FromFileName(sourceFile);

                string fileName = sourceFileInfo.Name;

                string targetFile = _path.Combine(doneFolder, fileName);

                var targetFileInfo = _factory.FromFileName(targetFile);

                if (targetFileInfo.Exists)
                {
                    targetFileInfo.Delete();
                }

                if (targetFileInfo.Directory.Exists == false)
                {
                    targetFileInfo.Directory.Create();
                }

                sourceFileInfo.MoveTo(targetFile);
            }

            return commandResult;
        }
    }
}
