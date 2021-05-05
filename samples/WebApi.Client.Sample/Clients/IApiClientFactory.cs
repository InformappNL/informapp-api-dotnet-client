using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Models.Requests;

namespace Informapp.InformSystem.WebApi.Client.Sample.Clients
{
    /// <summary>
    /// Factory interface to create instances of <see cref="IApiClient{TRequest, TResponse}"/>
    /// </summary>
    public interface IApiClientFactory
    {
        /// <summary>
        /// Create instace of <see cref="IApiClient{TRequest, TResponse}"/>
        /// </summary>
        /// <typeparam name="TRequest">The request type</typeparam>
        /// <typeparam name="TResponse">The response type</typeparam>
        /// <returns>An instance of <see cref="IApiClient{TRequest, TResponse}"/></returns>
        IApiClient<TRequest, TResponse> Create<TRequest, TResponse>()
            where TRequest : class, IRequest<TResponse>
            where TResponse : class, new();
    }
}
