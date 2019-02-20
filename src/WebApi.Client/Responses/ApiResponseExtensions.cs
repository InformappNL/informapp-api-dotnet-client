using Informapp.InformSystem.WebApi.Client.Arguments;
using System;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Responses
{
    /// <summary>
    /// Extensions for <see cref="ApiResponse"/>
    /// </summary>
    public static class ApiResponseExtensions
    {
        /// <summary>
        /// Throw exception if the api request failed
        /// </summary>
        /// <typeparam name="T">The type deriving from <see cref="ApiResponse"/></typeparam>
        /// <param name="response">The response</param>
        /// <returns>The response</returns>
        public static T ThrowIfFailed<T>(this T response)
            where T : ApiResponse
        {
            Argument.NotNull(response, nameof(response));

            if (response.IsSuccessful == false)
            {
                throw new InvalidOperationException("The request failed.");
            }

            return response;
        }

        /// <summary>
        /// Throw exception if the api request failed
        /// </summary>
        /// <typeparam name="T">The type deriving from <see cref="ApiResponse"/></typeparam>
        /// <param name="response">The response</param>
        /// <returns>The response</returns>
        public static async Task<T> ThrowIfFailed<T>(this Task<T> response)
            where T : ApiResponse
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            var result = await response;

            return ThrowIfFailed(result);
        }
    }
}
