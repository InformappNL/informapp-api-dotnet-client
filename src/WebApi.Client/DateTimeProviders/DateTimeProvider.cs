using System;

namespace Informapp.InformSystem.WebApi.Client.DateTimeProviders
{
    /// <summary>
    /// Implementation of <see cref="IDateTimeProvider"/>
    /// </summary>
    public class DateTimeProvider : IDateTimeProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeProvider"/> class.
        /// </summary>
        public DateTimeProvider()
        {

        }

        /// <summary>
        /// Gets a <see cref="DateTimeOffset"/> object whose date and time are set to the current
        /// Coordinated Universal Time (UTC) date and time and whose offset is <see cref="TimeSpan.Zero"/>.
        /// </summary>
        public DateTimeOffset UtcNow { get { return DateTimeOffset.UtcNow; } }
    }
}
