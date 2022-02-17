using ConnectedDevelopment.InformSystem.WebApi.Client.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.BearerTokenProviders
{
    /// <summary>
    /// Provider generic interface for bearer tokens
    /// </summary>
    public interface IBearerTokenProvider<T> //: IBearerTokenProvider
        where T : class
    {
        /// <summary>
        /// Get bearer token
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The token response</returns>
        Task<BearerTokenResponse> GetToken(ApiRequest request, CancellationToken cancellationToken);
    }
}
