using ConnectedDevelopment.InformSystem.WebApi.Client.Converters;
using ConnectedDevelopment.InformSystem.WebApi.Models.Http;
using RestSharp;
using System;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.RestSharp.Converters
{
    /// <summary>
    /// Implementation of <see cref="IConverter{TSource, TResult}"/>
    /// to convert <see cref="HttpMethod"/> to <see cref="Method"/>
    /// </summary>
    public class HttpMethodConverter : IConverter<HttpMethod?, Method?>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpMethodConverter"/> class.
        /// </summary>
        public HttpMethodConverter()
        {

        }

        /// <summary>
        /// Convert <see cref="HttpMethod"/> to <see cref="Method"/>
        /// </summary>
        /// <param name="source">The source value</param>
        /// <returns>The <see cref="ConvertResult{TResult}"/> containing the converted value</returns>
        /// <exception cref="ArgumentException">Unsupported value</exception>
        public ConvertResult<Method?> Convert(HttpMethod? source)
        {
            Method? method;

            switch (source)
            {
                case null:
                    method = null;
                    break;
                case HttpMethod.Get:
                    method = Method.GET;
                    break;
                case HttpMethod.Post:
                    method = Method.POST;
                    break;
                case HttpMethod.Put:
                    method = Method.PUT;
                    break;
                case HttpMethod.Delete:
                    method = Method.DELETE;
                    break;
                case HttpMethod.Head:
                    method = Method.HEAD;
                    break;
                case HttpMethod.Options:
                    method = Method.OPTIONS;
                    break;
                case HttpMethod.Patch:
                    method = Method.PATCH;
                    break;
                case HttpMethod.Merge:
                    method = Method.MERGE;
                    break;
                case HttpMethod.Copy:
                    method = Method.COPY;
                    break;
                default:
                    throw new ArgumentException("Unsupported value", nameof(source));
            }

            return ConvertResult.FromNullable(method);
        }
    }
}
