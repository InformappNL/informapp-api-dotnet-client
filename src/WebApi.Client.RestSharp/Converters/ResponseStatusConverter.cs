using Informapp.InformSystem.WebApi.Client.Converters;
using Informapp.InformSystem.WebApi.Client.Responses;
using RestSharp;
using System;

namespace Informapp.InformSystem.WebApi.Client.RestSharp.Converters
{
    /// <summary>
    /// Implementation of <see cref="IConverter{TSource, TResult}"/>
    /// to convert <see cref="ResponseStatus"/> to <see cref="ResponseStatusCode"/>
    /// </summary>
    public class ResponseStatusConverter : IConverter<ResponseStatus?, ResponseStatusCode?>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseStatusConverter"/> class.
        /// </summary>
        public ResponseStatusConverter()
        {

        }

        /// <summary>
        /// Convert <see cref="ResponseStatus"/> to <see cref="ResponseStatusCode"/>
        /// </summary>
        /// <param name="source">The source value</param>
        /// <returns>The <see cref="ConvertResult{TResult}"/> containing the converted value</returns>
        /// <exception cref="ArgumentException">Unsupported value</exception>
        public ConvertResult<ResponseStatusCode?> Convert(ResponseStatus? source)
        {
            ResponseStatusCode? code;

            switch (source)
            {
                case null:
                    code = null;
                    break;
                case ResponseStatus.None:
                    code = ResponseStatusCode.None;
                    break;
                case ResponseStatus.Completed:
                    code = ResponseStatusCode.Completed;
                    break;
                case ResponseStatus.Error:
                    code = ResponseStatusCode.Error;
                    break;
                case ResponseStatus.TimedOut:
                    code = ResponseStatusCode.TimedOut;
                    break;
                case ResponseStatus.Aborted:
                    code = ResponseStatusCode.Aborted;
                    break;
                default:
                    throw new ArgumentException("Unsupported value", nameof(source));
            }

            return ConvertResult.FromNullable(code);
        }
    }
}
