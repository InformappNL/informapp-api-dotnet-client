using System;

namespace Informapp.InformSystem.WebApi.Client.Converters
{
    /// <summary>
    /// Implementation of <see cref="IConverter{TSource, TResult}"/>
    /// to convert <see cref="string"/> to <see cref="Guid"/>
    /// </summary>
    public class StringToGuidConverter : IConverter<string, Guid?>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringToGuidConverter"/> class.
        /// </summary>
        public StringToGuidConverter()
        {

        }

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="Guid"/>
        /// </summary>
        /// <param name="source">The source value</param>
        /// <returns>The <see cref="ConvertResult{TResult}"/> containing the converted value</returns>
        public ConvertResult<Guid?> Convert(string source)
        {
            Guid? value = null;

            if (string.IsNullOrEmpty(source) == false)
            {
                if (Guid.TryParse(source, out var guid))
                {
                    value = guid;
                }
            }

            return ConvertResult.FromNullable(value);
        }
    }
}
