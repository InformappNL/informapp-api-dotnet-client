
namespace Informapp.InformSystem.WebApi.Client.Responses
{
    /// <summary>
    /// Response status codes
    /// </summary>
    public enum ResponseStatusCode
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,

        /// <summary>
        /// Completed
        /// </summary>
        Completed = 1,

        /// <summary>
        /// Error
        /// </summary>
        Error = 2,

        /// <summary>
        /// TimedOut
        /// </summary>
        TimedOut = 3,

        /// <summary>
        /// Aborted
        /// </summary>
        Aborted = 4
    }
}
