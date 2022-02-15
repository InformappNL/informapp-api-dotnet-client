using Informapp.InformSystem.WebApi.Client.Validators;
using Informapp.InformSystem.IntegrationTool.Core.Collections;
using Informapp.InformSystem.IntegrationTool.Core.Requires;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO.Abstractions;
using System.Linq;

namespace Informapp.InformSystem.IntegrationTool.Core.IntegrationExports
{
    /// <summary>
    /// Validates the file extension
    /// </summary>
    public class FileExtensionValidator : IValidator<DownloadIntegrationExportCommand>
    {
        private readonly IPath _path;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileExtensionValidator"/> class.
        /// </summary>
        /// <param name="path">Injected file path provider</param>
        public FileExtensionValidator(
            IPath path)
        {
            Argument.NotNull(path, nameof(path));

            _path = path;
        }

        /// <summary>
        /// Validates the file extension of the provided file
        /// </summary>
        /// <param name="instance">The command instance</param>
        public void ValidateObject(DownloadIntegrationExportCommand instance)
        {
            Argument.NotNull(instance, nameof(instance));

            var configuration = instance.Configuration;

            Require.NotNull(configuration, nameof(configuration));

            bool isValid;

            if (configuration.Extensions != null)
            {
                var extensions = configuration.Extensions
                    .Where(x => string.IsNullOrEmpty(x) == false)
                    .Select(x => x[0] == '.' ? x : string.Concat(".", x))
                    .ToHashSet(StringComparer.OrdinalIgnoreCase);

                var extension = _path.GetExtension(instance.FileName);

                isValid = extensions.Contains(extension);
            }
            else
            {
                isValid = false;
            }

            if (isValid == false)
            {
                throw new ValidationException("Extension is not allowed.");
            }
        }
    }
}
