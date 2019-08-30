
namespace Informapp.InformSystem.WebApi.Models.Http
{
    /// <summary>
    /// Static class containing constants for content types
    /// </summary>
    public static class ContentTypeConstants
    {
        /// <summary>
        /// Char used in response header to separate multiple content types
        /// </summary>
        public const char ResponseHeaderSeparator = ';';

        /// <summary>
        /// application content
        /// </summary>
        public static class Application
        {
            /// <summary>
            /// application/x-www-form-urlencoded
            /// </summary>
            public const string FormUrlEncoded = "application/x-www-form-urlencoded";

            /// <summary>
            /// application/json
            /// </summary>
            public const string Json = "application/json";

            /// <summary>
            /// application/octet-stream
            /// </summary>
            public const string OctetStream = "application/octet-stream";

            /// <summary>
            /// application/xml
            /// </summary>
            public const string Xml = "application/xml";
        }

        /// <summary>
        /// Multipart content
        /// </summary>
        public static class MultiPart
        {
            /// <summary>
            /// multipart/form-data
            /// </summary>
            public const string FormData = "multipart/form-data";
        }
    }
}
