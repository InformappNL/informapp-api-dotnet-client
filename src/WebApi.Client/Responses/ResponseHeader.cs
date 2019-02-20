using System.Diagnostics;
using System.Globalization;

namespace Informapp.InformSystem.WebApi.Client.Responses
{
    /// <summary>
    /// Response header class
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ", nq}")]
    public class ResponseHeader
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture, "Header: {0}={1}", Name, Value);
            }
        }
    }
}
