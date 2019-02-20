using Informapp.InformSystem.WebApi.Client.Arguments;
using Informapp.InformSystem.WebApi.Models.Http;

namespace Informapp.InformSystem.WebApi.Client.Requests
{
    /// <summary>
    /// Extensions for <see cref="ApiRequest"/>
    /// </summary>
    public static class ApiRequestExtensions
    {
        /// <summary>
        /// Set method to <see cref="HttpMethod.Head"/>
        /// </summary>
        /// <typeparam name="T">The type deriving from <see cref="ApiRequest"/></typeparam>
        /// <param name="request">The request</param>
        /// <returns>The request</returns>
        public static T Head<T>(this T request)
            where T : ApiRequest
        {
            Argument.NotNull(request, nameof(request));

            if (request.Context == null)
            {
                request.Context = new RequestContext();
            }

            request.Context.Method = HttpMethod.Head;

            return request;
        }
    }
}
