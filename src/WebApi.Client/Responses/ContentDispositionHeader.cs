using ConnectedDevelopment.InformSystem.WebApi.Client.Arguments;
using System;
using System.Net.Mime;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Responses
{
    /// <summary>
    /// Content-Disposition header
    /// </summary>
    public class ContentDispositionHeader
    {
        private readonly ContentDisposition _contentDisposition;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentDispositionHeader"/> class.
        /// </summary>
        /// <param name="disposition">A <see cref="DispositionTypeNames"/> value that contains the disposition.</param>
        public ContentDispositionHeader(
            string disposition)
        {
            Argument.NotNullOrEmpty(disposition, nameof(disposition));

            _contentDisposition = new ContentDisposition(disposition);

            if (string.IsNullOrEmpty(FileName) == false)
            {
                FileName = Uri.UnescapeDataString(FileName);

                FileName = RemoveDoubleQuotes(FileName);
            }
        }

        /// <summary>
        /// Disposition type
        /// </summary>
        public string DispositionType
        {
            get => _contentDisposition.DispositionType;
            set => _contentDisposition.DispositionType = value;
        }

        /// <summary>
        /// File name
        /// </summary>
        public string FileName
        {
            get => _contentDisposition.FileName;
            set => _contentDisposition.FileName = value;
        }

        /// <summary>
        /// Returns a <see cref="string"/> representation of this instance.
        /// </summary>
        /// <returns>A <see cref="string"/> that contains the property values for this instance.</returns>
        public override string ToString()
        {
            return _contentDisposition.ToString();
        }

        private static string RemoveDoubleQuotes(string value)
        {
            if (string.IsNullOrEmpty(value) == false &&
                value.Length > 1 &&
                value[0] == '\"' && value[value.Length - 1] == '\"')
            {
                value = value.Substring(1, value.Length - 2);
            }

            return value;
        }
    }
}
