
namespace ConnectedDevelopment.InformSystem.WebApi.Models.Requests
{
    /// <summary>
    /// Generic IRequest interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRequest<T> : IRequest
        where T : class
    {

    }
}
