
namespace ConnectedDevelopment.InformSystem.WebApi.Client.MimeMappers
{
    /// <summary>
    /// Maps document extensions to content MIME types.
    /// </summary>
    public interface IMimeMapper
    {
        /// <summary>
        /// Returns the MIME mapping for the specified file name.
        /// </summary>
        /// <param name="fileName">The file name that is used to determine the MIME type.</param>
        /// <returns>Returns the MIME mapping for the specified file name.</returns>
        string GetMimeMapping(string fileName);
    }
}
