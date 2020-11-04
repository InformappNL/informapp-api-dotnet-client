using System;

namespace Informapp.InformSystem.WebApi.Models.Http
{
    /// <summary>
    /// Indicates the content type to use for a request
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public sealed class ContentTypeAttribute : Attribute
    {
        /// <summary>
        /// Content type
        /// </summary>
        public ContentType ContentType { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentTypeAttribute"/> class.
        /// </summary>
        public ContentTypeAttribute(ContentType contentType)
        {
            switch (contentType)
            {
                case ContentType.Json:
                case ContentType.FormUrlEncoded:
                    break;
                default:
                    throw new ArgumentException("Unsupported value", nameof(contentType));
            }

            ContentType = contentType;
        }
    }
}
