using ConnectedDevelopment.InformSystem.WebApi.Client.Arguments;
using System;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Responses
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
                const string message = "The request failed.";

                if (response.ErrorException != null)
                {
                    throw new InvalidOperationException(message, response.ErrorException);
                }

                else
                {
                    throw new InvalidOperationException(message);
                }
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
            Argument.NotNull(response, nameof(response));

            var result = await response
                .ConfigureAwait(Await.Default);

            return ThrowIfFailed(result);
        }
    }
}
