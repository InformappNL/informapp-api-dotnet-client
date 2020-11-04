using Informapp.InformSystem.WebApi.Client.Arguments;
using MimeMapping;

namespace Informapp.InformSystem.WebApi.Client.MimeMappers
{
    /// <summary>
    /// Maps document extensions to content MIME types.
    /// </summary>
    public class MimeMapper : IMimeMapper
    {
        /// <summary>
        /// Returns the MIME mapping for the specified file name.
        /// </summary>
        /// <param name="fileName">The file name that is used to determine the MIME type.</param>
        /// <returns>Returns the MIME mapping for the specified file name.</returns>
        public string GetMimeMapping(string fileName)
        {
            Argument.NotNullOrEmpty(fileName, nameof(fileName));

            return MimeUtility.GetMimeMapping(fileName);
        }
    }
}
