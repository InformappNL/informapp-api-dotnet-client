using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Requests
{
    /// <summary>
    /// Base request
    /// </summary>
    [DataContract(Namespace = RequestConstants.Namespace)]
    public abstract class BaseRequest
    {

    }
}
