using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Client.Validators;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO.Abstractions;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.IntegrationExports
{
    /// <summary>
    /// Validates the file name
    /// </summary>
    public class FileNameValidator : IValidator<DownloadIntegrationExportCommand>
    {
        private readonly IPath _path;

        private readonly IFileInfoFactory _fileInfoFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileNameValidator"/> class.
        /// </summary>
        /// <param name="filePathProvider">Injected file path provider</param>
        /// <param name="path">Injected file info factory</param>
        public FileNameValidator(
            IPath filePathProvider,
            IFileInfoFactory path)
        {
            Argument.NotNull(filePathProvider, nameof(filePathProvider));
            Argument.NotNull(path, nameof(path));

            _path = filePathProvider;

            _fileInfoFactory = path;
        }

        /// <summary>
        /// Validates the file name of the provided file
        /// </summary>
        /// <param name="instance">The command instance</param>
        public void ValidateObject(DownloadIntegrationExportCommand instance)
        {
            Argument.NotNull(instance, nameof(instance));

            var configuration = instance.Configuration;

            Require.NotNull(configuration, nameof(configuration));

            string integrationPath = _path.Combine(configuration.Folder, instance.FileName);

            var integrationFile = _fileInfoFactory.FromFileName(integrationPath);

            string actualFolder = _path.GetDirectoryName(integrationFile.FullName);

            string configuredFolder = _path.GetDirectoryName(configuration.Folder);

            bool isValid = string.Equals(actualFolder, configuredFolder, StringComparison.Ordinal);

            if (isValid == false)
            {
                throw new ValidationException("Filename changes configured integration folder.");
            }
        }
    }
}
