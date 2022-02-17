using System;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.DateTimeProviders
{
    /// <summary>
    /// Interface to provide date and time
    /// </summary>
    public interface IDateTimeProvider
    {
        /// <summary>
        /// Gets a <see cref="DateTimeOffset"/> object whose date and time are set to the current
        /// Coordinated Universal Time (UTC) date and time and whose offset is <see cref="TimeSpan.Zero"/>.
        /// </summary>
        DateTimeOffset UtcNow { get; }
    }
}
